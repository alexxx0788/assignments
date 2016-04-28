using System;
using System.Collections.Generic;
using System.Web.Configuration;

namespace MovieSearcherApi.MovieRepo
{
    public abstract class MovieApiRepo
    {
        public string Key { get; set; }
        public string Url { get; set; }
        public string ItemsOnPage { get; set; }
        public string SingleMovie { get; set; }
        protected MovieApiRepo()
        {
            InitPropertiesFromConfig();
        }

        private void InitPropertiesFromConfig()
        {
            var currType = GetType();
            var baseType = currType.BaseType;
            var apiName = currType.Name.Replace(baseType.Name, string.Empty);
            var props = currType.GetProperties();
            foreach (var prop in props)
            {
                var value = WebConfigurationManager.AppSettings[String.Format("{0}.api.{1}", apiName, prop.Name)];
                if (!String.IsNullOrEmpty(value))
                {
                    currType.GetProperty(prop.Name).SetValue(this, value, null);
                }
            }
        }

        public abstract string BuildQuery();
        public abstract IEnumerable<Movie> SearchMovies(string title,int offset=0);


        public MovieApiRepo Source
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual IEnumerable<Movie> GetMoviesList(string title)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Movie> GetMovieById(string movId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Movie> GetMoviesList(string title, string year)
        {
            throw new NotImplementedException();
        }
    }
}
