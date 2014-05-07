using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class ArtistApiController : ApiController
    {
        public IEnumerable<KeyValuePair<int, string>> Get()
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var artists = ctx.Artists.Select(q => new { q.Name, q.ArtistId })
                                   .ToDictionary(k => k.ArtistId, v => v.Name).ToList();
                artists.Insert(0, new KeyValuePair<int, string>(0, string.Empty));
                return artists;
            }
        }
    }
}
