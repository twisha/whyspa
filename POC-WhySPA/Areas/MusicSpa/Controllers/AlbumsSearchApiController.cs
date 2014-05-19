using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using POC_WhySPA.Areas.MusicSpa.Models;
using POC_WhySPA.Areas.MusicSpa.Models.Albums;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class AlbumsSearchApiController : ApiController
    {
        public IEnumerable<AlbumSummary> Get(int genreId = 0)
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
