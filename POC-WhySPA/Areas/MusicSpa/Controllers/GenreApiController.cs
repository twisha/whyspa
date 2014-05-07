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
                var genres = ctx.Genres.Select(q => new { q.Name, q.GenreId })
                                   .ToDictionary(k => k.GenreId, v => v.Name).ToList();
                genres.Insert(0, new KeyValuePair<int, string>(0, string.Empty));
                return genres;
            }
        }
    }
}
