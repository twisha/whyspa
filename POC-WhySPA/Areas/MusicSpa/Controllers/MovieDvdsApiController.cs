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
    public class MovieDvdsApiController : ApiController
    {
        public MovieDvdDetail Get(int id)
        {
            //TODO: Repository implementation is pending.
            using (var ctx = new MvcMusicStoreEntities())
            {
                var movieDvdRaw = (from movieDvd in ctx.MovieDvds
                where movieDvd.MovieDvdId == id
                join genre in ctx.MovieGenres on movieDvd.MovieGenreId equals genre.MovieGenreId
                select new {movieDvd, genre}).SingleOrDefault();
                if (movieDvdRaw == null) throw new HttpResponseException(HttpStatusCode.NotFound);
                var movieDvdDetail = new MovieDvdDetail
                    {
                        Id = movieDvdRaw.movieDvd.MovieDvdId,
                        Title = movieDvdRaw.movieDvd.Title,
                        Price = movieDvdRaw.movieDvd.Price,
                        Genre = new KeyValuePair<int, string>(movieDvdRaw.genre.MovieGenreId, movieDvdRaw.genre.Name)
                    };
                return movieDvdDetail;
            }
        }

        public void Put(int id, MovieDvdDetail movieDvd)
        {
            using (var ctx = new MvcMusicStoreEntities())
            {
                var movieDvdRaw = ctx.MovieDvds.SingleOrDefault(q => q.MovieDvdId == id);
                if (movieDvdRaw == null) throw new HttpResponseException(HttpStatusCode.NotFound);
                //TODO: Use Automapper instead
                movieDvdRaw.Title = movieDvd.Title;
                movieDvdRaw.Price = movieDvd.Price;
                movieDvdRaw.MovieGenreId = movieDvd.Genre.Key;
                ctx.SaveChanges();
            }
        }
    }
}
