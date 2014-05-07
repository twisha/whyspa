using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POC_WhySPA.Areas.Music.Models;
using POC_WhySPA.Areas.Music.ViewModels.Albums;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.Music.Controllers
{
    public class AlbumsController : Controller
    {
        //
        // GET: /Music/Albums/
        //NOTE: GET & POST are essentially the same here. demo the url driven nature when GET action method.
        public ActionResult Index(int SelectedGenre = 0)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var genresRaw = ctx.Genres.Select(q => new { q.Name, q.GenreId })
                                   .ToList();
                var genres =
                    genresRaw.Select(q => new SelectListItem { Text = q.Name, Value = string.Format("{0}", q.GenreId) }).ToList();
                genres.Insert(0, new SelectListItem());
                var albumsRaw = (from album in ctx.Albums
                                 join artist in ctx.Artists on album.ArtistId equals artist.ArtistId
                                 join genre in ctx.Genres on album.GenreId equals genre.GenreId
                                 where album.GenreId == (SelectedGenre == 0 ? album.GenreId : SelectedGenre)
                                 orderby album.Title
                                 select new { album, artist, genre }).ToList();

                var model = new IndexModel
                    {
                        Genres =
                            genres,
                        Albums = albumsRaw.Select(
                            q =>
                            new AlbumSummary
                                {
                                    Id = q.album.AlbumId,
                                    Title = q.album.Title,
                                    Price = q.album.Price,
                                    Artist = new ArtistSummary { Id = q.artist.ArtistId, Name = q.artist.Name },
                                    Genre = q.genre.Name
                                }),
                        SelectedGenre = SelectedGenre
                    };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var genresRaw = ctx.Genres.Select(q => new { q.Name, q.GenreId })
                                   .ToList();
                var genres =
                    genresRaw.Select(q => new SelectListItem { Text = q.Name, Value = string.Format("{0}", q.GenreId) })
                             .ToList();
                genres.Insert(0, new SelectListItem());
                var albumsRaw = (from album in ctx.Albums
                                 join artist in ctx.Artists on album.ArtistId equals artist.ArtistId
                                 join genre in ctx.Genres on album.GenreId equals genre.GenreId
                                 where album.GenreId == (model.SelectedGenre == 0 ? album.GenreId : model.SelectedGenre)
                                 orderby album.Title
                                 select new { album, artist, genre }).ToList();

                //Repopulate!
                model.Genres = genres;
                model.Albums = albumsRaw.Select(q =>
                                                new AlbumSummary
                                                    {
                                                        Id = q.album.AlbumId,
                                                        Title = q.album.Title,
                                                        Price = q.album.Price,
                                                        Artist =
                                                            new ArtistSummary
                                                                {
                                                                    Id = q.artist.ArtistId,
                                                                    Name = q.artist.Name
                                                                },
                                                        Genre = q.genre.Name
                                                    });
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var album = ctx.Albums.SingleOrDefault(q => q.AlbumId == id);
                if (album == null) throw new InvalidOperationException("Invalid request.");
                var genresRaw = ctx.Genres.Select(q => new { q.Name, q.GenreId })
                                   .ToList();
                var genres =
                    genresRaw.Select(q => new SelectListItem { Text = q.Name, Value = string.Format("{0}", q.GenreId) }).ToList();
                genres.Insert(0, new SelectListItem());
                var artistsRaw = ctx.Artists.Select(q => new { q.Name, q.ArtistId })
                                   .ToList();
                var artists =
                    artistsRaw.Select(q => new SelectListItem { Text = q.Name, Value = string.Format("{0}", q.ArtistId) }).ToList();
                genres.Insert(0, new SelectListItem());
                var model = new AlbumEditModel
                    {
                        Id = album.AlbumId,
                        Title = album.Title,
                        GenreId = album.GenreId,
                        Genres = genres,
                        ArtistId = album.ArtistId,
                        Artists = artists,
                        Price = album.Price
                    };
                return View(model);
            }
        }
    }
}
