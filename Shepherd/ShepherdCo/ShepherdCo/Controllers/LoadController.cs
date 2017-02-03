using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class LoadController : ApiController
    {
        public void Get()
        {
            StockRepository stockController = new StockRepository(new SqlConnection(Helper.ConnectionString));
            stockController.DeleteAll();
            List<string> companies = new List<string>();
            while (companies.Count < 10)
            {
                var stock = DummyData.GetTestCompanyStock();
                if (!companies.Contains(stock.Company))
                {
                    stockController.Insert(stock);
                    companies.Add(stock.Company);
                }
            }
        }
    }
}
