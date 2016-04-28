using System;
using System.Collections.Generic;
using System.Web.Helpers;
using MovieSearcherApi.MovieRepo;
using MovieSearcherApi.MovieRepo.imdb;

namespace MovieSearcherSite.Areas.Imdb.Models
{
    public class ImdbRepository 
    {
        public MovieApiRepo Source { get;set; }
        public ImdbRepository()
        {
            Source = new ImdbMovieApiRepo();
        }

        private IEnumerable<Movie> GetFromCache(string key)
        {
            if (WebCache.Get(key) != null)
            {
                return (IEnumerable<Movie>)WebCache.Get(key);
            }
            return null;
        }

        public IEnumerable<Movie> GetMoviesList(string title)
        {
            IEnumerable<Movie> movies = GetFromCache(title);
            if (movies == null)
            {
                movies = Source.SearchMovies(title);
                WebCache.Set(title, movies, 300);
            }
            return movies;
        }

        public IEnumerable<Movie> GetMovieById(string movId)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetBookList(string title, string year)
        {
            throw new NotImplementedException();
        }
    }
}
 