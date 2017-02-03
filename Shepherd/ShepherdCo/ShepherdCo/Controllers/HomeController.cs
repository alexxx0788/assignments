using System.Data.SqlClient;
using System.Web.Mvc;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order(int id)
        {
            var stockController = new StockRepository(new SqlConnection(Helper.ConnectionString));
            var stock = stockController.GetEntryById(id);
            return PartialView("Order", stock);
        }

        public ActionResult Balance()
        {
            var userController = new UserRepository(new SqlConnection(Helper.ConnectionString));
            var user = userController.GetEntryById(Helper.UserId);
            return PartialView("Balance", user);
        }

        public ActionResult ViewOrders()
        {
            OrderRepository orderController = new OrderRepository(new SqlConnection(Helper.ConnectionString));
            var orders = orderController.GetListOfOrders(Helper.UserId); 
            return PartialView("ViewOrders", orders);
        }

        public ActionResult ReloadStocks()
        {
            return PartialView("ReloadStocks");
        }
    }
}
