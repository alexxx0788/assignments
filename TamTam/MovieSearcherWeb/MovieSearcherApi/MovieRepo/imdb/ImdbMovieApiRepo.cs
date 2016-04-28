using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using MovieSearcherApi.Common;

namespace MovieSearcherApi.MovieRepo.imdb
{
    public class ImdbMovieApiRepo : MovieApiRepo
    {
        public override IEnumerable<Movie> SearchMovies(string title,int offset=0)
        {
            var url = new UriBuilder(BuildQuery());
            var query = HttpUtility.ParseQueryString(url.Query);
            query["title"] = title;
            query["offset"] = offset.ToString();
            url.Query = query.ToString();
            var doc = Utils.RequestXmlFeed(url.ToString());
            List<Movie> movs = new List<Movie>();
            if (doc!=null && doc.SelectNodes(SingleMovie) != null)
            {
                var nodes = doc.SelectNodes(SingleMovie);
                foreach (XmlNode selectNode in nodes)
                {
                   Movie mov = new ImdbMovie(selectNode);
                   if (!movs.Any(l => l.IdImdb == mov.IdImdb))
                   {
                       movs.Add(mov);
                   }
                }
            }
            return movs;
        }

        public override string BuildQuery()
        {
            var url = new UriBuilder(Url);
            var param = HttpUtility.ParseQueryString(string.Empty);
            param["token"] = Key;
            param["format"] = "xml";
            param["language"] = "en-us";
            int limit = 0;
            param["limit"] = int.TryParse(ItemsOnPage, out limit) ?  ItemsOnPage : "5";
            url.Query = param.ToString();
            return url.Uri.ToString();
        }
    }
}
