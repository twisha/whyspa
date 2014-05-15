using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_WhySPA.Areas.MusicSpa.Models.MovieDvds
{
    public class MovieDvdSummary
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Genre { get; set; }
    }
}