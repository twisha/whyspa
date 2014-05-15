using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class MovieGenreApiController : ApiController
    {
        public IEnumerable<KeyValuePair<int, string>> Get()
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var movieGenresRaw = ctx.MovieGenres.Select(q => new { q.MovieGenreId, q.Name }).ToList();
                var movieGenres = movieGenresRaw.Select(q => new KeyValuePair<int, string>(q.MovieGenreId, q.Name));
                return movieGenres;
            }
        }
    }
}
