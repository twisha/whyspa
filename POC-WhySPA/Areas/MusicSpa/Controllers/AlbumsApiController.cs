using System.Net;
using System.Web.Http;
using POC_WhySPA.Areas.MusicSpa.Models.Albums;
using StructureMap.Attributes;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class AlbumsApiController : ApiController
    {
        [SetterProperty]
        public IAlbumsRepository AlbumsRepository { get; set; }

        public AlbumDetail Get(int id)
        {
            var albumDetail = AlbumsRepository.Get(id);
            if (albumDetail == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return albumDetail;
        }

        public void Put(int id, AlbumDetail album)
        {
            var albumExists = AlbumsRepository.CheckAlbumExists(id);
            if (!albumExists) throw new HttpResponseException(HttpStatusCode.NotFound);
            album.Id = id;
            AlbumsRepository.Save(album);
        }
    }
}
