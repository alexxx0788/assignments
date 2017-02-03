namespace ShepherdCo.Controllers
{
    public static class Helper
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ShepherdDb"].ConnectionString;

        public static int UserId = 1;
    }
}