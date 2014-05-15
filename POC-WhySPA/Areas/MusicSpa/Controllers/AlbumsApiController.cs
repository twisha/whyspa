using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using POC_WhySPA.Areas.MusicSpa.Models;
using POC_WhySPA.Areas.MusicSpa.Models.Albums;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class AlbumsApiController : ApiController
    {
        public AlbumDetail Get(int id)
        {
            //TODO: Repository implementation is pending.
            using (var ctx = new MvcMusicStoreEntities())
            {
                var albumRaw = (from album in ctx.Albums
                                where album.AlbumId == id
                                join artist in ctx.Artists on album.ArtistId equals artist.ArtistId
                                join genre in ctx.Genres on album.GenreId equals genre.GenreId
                                select new {album, artist, genre}).SingleOrDefault();
                if (albumRaw == null) throw new HttpResponseException(HttpStatusCode.NotFound);
                var albumDetail = new AlbumDetail
                    {
                        Id = albumRaw.album.AlbumId,
                        Title = albumRaw.album.Title,
                        Price = albumRaw.album.Price,
                        Artist = new KeyValuePair<int, string>(albumRaw.artist.ArtistId, albumRaw.artist.Name),
                        Genre = new KeyValuePair<int, string>(albumRaw.genre.GenreId, albumRaw.genre.Name)
                    };
                return albumDetail;
            }
        }

        public void Put(int id, AlbumDetail album)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var albumRaw = ctx.Albums.SingleOrDefault(q => q.AlbumId == id);
                if (albumRaw == null) throw new HttpResponseException(HttpStatusCode.NotFound);
                //TODO: Use Automapper instead
                albumRaw.Title = album.Title;
                albumRaw.Price = album.Price;
                albumRaw.ArtistId = album.Artist.Key;
                albumRaw.GenreId = album.Genre.Key;
                ctx.SaveChanges();
            }
        }
    }
}
