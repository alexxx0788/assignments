using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Mvc;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class OrderController : ApiController
    {
        const string StockIdJs = "stockId";
        const string AmountJs = "amount";

        // POST api/order
        public JsonResult Post(dynamic item)
        {
            var stockId = 0;
            var amount = 0;
            int.TryParse(item[StockIdJs].Value, out stockId);
            int.TryParse(item[AmountJs].Value, out amount);
         
            StockRepository stockRepo = new StockRepository(new SqlConnection(Helper.ConnectionString));
            var stock = stockRepo.GetEntryById(stockId);
            if (stock.Amount < amount)
            {
                var result = new Responce() {Message = "Not enought stocks to buy",Status = false};
                return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                MakeOrder(stockId,amount);
                var result = new Responce() { Message = "Conratulation!!!", Status = true };
                return new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
        }

        private void MakeOrder(int stockId,int amount)
        {
            OrderRepository orderRepository = new OrderRepository(new SqlConnection(Helper.ConnectionString));
            orderRepository.Insert(Helper.UserId, stockId, amount);
        }
    }
}
