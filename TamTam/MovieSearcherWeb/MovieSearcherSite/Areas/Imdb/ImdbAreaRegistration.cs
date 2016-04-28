using System.Web.Mvc;

namespace MovieSearcherSite.Areas.Imdb
{
    public class ImdbAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Imdb";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Imdb_default",
                "Imdb/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
