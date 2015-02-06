using System.Collections.Generic;
using System.Linq;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.MusicSpa.Models.Albums
{
    public class AlbumsRepository : IAlbumsRepository
    {
        public AlbumDetail Get(int id)
        {
            AlbumDetail albumDetail = null;
            using (var ctx = new MvcMusicStoreEntities())
            {
                var albumRaw = (from album in ctx.Albums
                                where album.AlbumId == id
                                join artist in ctx.Artists on album.ArtistId equals artist.ArtistId
                                join genre in ctx.Genres on album.GenreId equals genre.GenreId
                                select new { album, artist, genre }).SingleOrDefault();
                if (albumRaw != null)
                {
                    albumDetail = new AlbumDetail
                    {
                        Id = albumRaw.album.AlbumId,
                        Title = albumRaw.album.Title,
                        Price = albumRaw.album.Price,
                        Artist = new KeyValuePair<int, string>(albumRaw.artist.ArtistId, albumRaw.artist.Name),
                        Genre = new KeyValuePair<int, string>(albumRaw.genre.GenreId, albumRaw.genre.Name)
                    };
                }
            }
            return albumDetail;
        }

        public bool CheckAlbumExists(int id)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                return ctx.Albums.Any(q => q.AlbumId == id);
            }    
        }

        public void Save(AlbumDetail album)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var albumRaw = ctx.Albums.Single(q => q.AlbumId == album.Id);
                //TODO: Use Automapper instead?
                albumRaw.Title = album.Title;
                albumRaw.Price = album.Price;
                albumRaw.ArtistId = album.Artist.Key;
                albumRaw.GenreId = album.Genre.Key;
                ctx.SaveChanges();
            }
        }

        public void Add(AlbumDetail album)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                ctx.Albums.Add(new Album
                {
                    Title = album.Title,
                    Price = album.Price,
                    ArtistId = album.Artist.Key,
                    GenreId = album.Genre.Key
                });
                ctx.SaveChanges();
            }
        }

        public IEnumerable<AlbumSummary> Search(int genreId)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var albums = (from album in ctx.Albums
                              join artist in ctx.Artists on album.ArtistId equals artist.ArtistId
                              join genre in ctx.Genres on album.GenreId equals genre.GenreId
                              where album.GenreId == (genreId == 0 ? album.GenreId : genreId)
                              orderby album.Title
                              select new AlbumSummary
                              {
                                  Id = album.AlbumId,
                                  Title = album.Title,
                                  Price = album.Price,
                                  Artist = artist.Name,
                                  Genre = genre.Name
                              }).ToList();
                return albums;
            }
        }
    }
}