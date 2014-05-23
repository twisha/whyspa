using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace POC_WhySPA.Areas.Music.ViewModels.Albums
{
    public class AlbumEditModel
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.AlbumEdit))]
        public string Title { get; set; }

        [Display(Name = "Genre", ResourceType = typeof(Resources.AlbumEdit))]
        public int GenreId { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        [Display(Name = "Artist", ResourceType = typeof(Resources.AlbumEdit))]
        public int ArtistId { get; set; }

        public IEnumerable<SelectListItem> Artists { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.AlbumEdit))]
        public decimal Price { get; set; }
    }
}