using System.Xml;

namespace MovieSearcherApi.MovieRepo.imdb
{
    public class ImdbMovie : Movie
    {
        public ImdbMovie(XmlNode doc) : base(doc) { }
    }
}
