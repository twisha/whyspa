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
                var artistsRaw = ctx.Artists.Select(q => new { q.Name, q.ArtistId }).ToList();
                var artists = artistsRaw.Select(q => new KeyValuePair<int, string>(q.ArtistId, q.Name));
                return artists;
            }
        }
    }
}
