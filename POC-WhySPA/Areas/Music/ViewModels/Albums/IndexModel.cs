using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using POC_WhySPA.Areas.Music.Models;

namespace POC_WhySPA.Areas.Music.ViewModels.Albums
{
    public class IndexModel
    {
        public IEnumerable<SelectListItem> Genres { get; set; }

        [Display(Name = "LabelGenres", ResourceType = typeof(Resources.Albums))]
        public int SelectedGenre { get; set; }

        //TODO: Temporarily using model instead of viewmodel
        public IEnumerable<AlbumSummary> Albums { get; set; }
    }
}