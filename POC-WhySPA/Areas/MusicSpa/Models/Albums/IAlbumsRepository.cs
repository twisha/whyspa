using System.Collections.Generic;

namespace POC_WhySPA.Areas.MusicSpa.Models.Albums
{
    public interface IAlbumsRepository
    {
        AlbumDetail Get(int id);

        bool CheckAlbumExists(int id);

        void Save(AlbumDetail album);

        void Add(AlbumDetail album);

        IEnumerable<AlbumSummary> Search(int genreId);
    }
}