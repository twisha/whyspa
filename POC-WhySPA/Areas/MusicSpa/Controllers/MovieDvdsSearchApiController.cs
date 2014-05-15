using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POC_WhySPA.Areas.MusicSpa.Models.MovieDvds;
using POC_WhySPA.Models;

namespace POC_WhySPA.Areas.MusicSpa.Controllers
{
    public class MovieDvdsSearchApiController : ApiController
    {
        public IEnumerable<MovieDvdSummary> Get(int genreId = 0)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var movieDvds = (from movieDvd in ctx.MovieDvds
                                 join genre in ctx.MovieGenres on movieDvd.MovieGenreId equals genre.MovieGenreId
                                 where movieDvd.MovieGenreId == (genreId == 0 ? movieDvd.MovieGenreId : genreId)
                                 orderby movieDvd.Title
                                 select new MovieDvdSummary
                                     {
                                         Id = movieDvd.MovieDvdId,
                                         Title = movieDvd.Title,
                                         Price = movieDvd.Price,
                                         Genre = genre.Name
                                     }).ToList();
                return movieDvds;
            }
        }
    }
}
