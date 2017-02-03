using System.Collections.Generic;
using System.Data;
using System.Linq;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository.Db;

namespace ShepherdCoAPI.Repository
{
    public class StockRepository : DbRepository<Stock>
    {
        public StockRepository(IDbConnection connection) : base(connection)
        {
            
        }
    }
}
