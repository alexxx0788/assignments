using System.Web.Mvc;
using MovieSearcherSite.Areas.Imdb.Models;

namespace MovieSearcherSite.Areas.Imdb.Controllers
{
    public class MovieController : Controller
    {
        public PartialViewResult GetMovies(string title)
        {
            var repo = new ImdbRepository();
            var movs = repo.GetMoviesList(title);
            return PartialView("Movie", movs);
        }
	}
}