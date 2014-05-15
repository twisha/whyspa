using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class GenreApiController : ApiController
    {
        public IEnumerable<KeyValuePair<int, string>> Get()
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var genresRaw = ctx.Genres.Select(q => new { q.Name, q.GenreId }).ToList();
                var genres = genresRaw.Select(q=>new KeyValuePair<int, string>(q.GenreId,q.Name));
                return genres;
            }
        }
    }
}
