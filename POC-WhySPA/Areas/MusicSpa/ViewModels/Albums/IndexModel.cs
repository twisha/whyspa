using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace POC_WhySPA.Areas.MusicSpa.ViewModels.Albums
{
    public class IndexModel
    {
        public IEnumerable<SelectListItem> Genres { get; set; }

        [Display(Name = "LabelGenres", ResourceType = typeof(MusicSpa.Resources.Albums))]
        public int SelectedGenre { get; set; }
    }
}