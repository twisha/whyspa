using System.Collections.Generic;

namespace POC_WhySPA.Areas.MusicSpa.Models
{
    public class AlbumSummary
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public KeyValuePair<int,string> Artist { get; set; }

        public decimal Price { get; set; }

        public string Genre { get; set; }
    }
}