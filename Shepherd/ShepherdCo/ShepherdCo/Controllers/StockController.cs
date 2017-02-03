using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class StockController : ApiController
    {
        
        // GET api/stock
        public IEnumerable<StockView> Get()
        {
            StockRepository stockController = new StockRepository(new SqlConnection(Helper.ConnectionString));
            var items = stockController.GetList(); // move to configuration
            var list = new List<StockView>();
            foreach (var item in items)
            {
                var stockView = DummyData.AdaptToStockView(item);
                item.Price = stockView.Price;
                stockController.Update(item, item.StockId);
                list.Add(stockView);
            }
            return list;
        }
    }
}
