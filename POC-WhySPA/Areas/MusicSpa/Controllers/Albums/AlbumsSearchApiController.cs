using System.Collections.Generic;
using System.Web.Http;
using POC_WhySPA.Areas.MusicSpa.Models.Albums;
using StructureMap.Attributes;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class AlbumsSearchApiController : ApiController
    {
        [SetterProperty]
        public IAlbumsRepository AlbumsRepository { get; set; }
        
        public IEnumerable<AlbumSummary> Get(int genreId = 0)
        {
            var albums = AlbumsRepository.Search(genreId);
            return albums;
        }
    }
}
