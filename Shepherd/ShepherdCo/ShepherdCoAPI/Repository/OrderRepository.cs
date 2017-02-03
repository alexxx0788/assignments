using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using Dapper;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository.Db;

namespace ShepherdCoAPI.Repository
{
    public class OrderRepository : DbRepository<Order>
    {
        public OrderRepository(IDbConnection connection) : base(connection){}

        public void Insert(int userId,int stockId,int amount)
        {
            var param = new DynamicParameters();
            param.Add("@UserId", userId);
            param.Add("@StockId", stockId);
            param.Add("@Amount", amount);
            Db.Query("InsertOrder",
                param: param,
                commandType: CommandType.StoredProcedure);
           
        }

        public IEnumerable<Order> GetListOfOrders(int userId)
        {
            var  param = new DynamicParameters();
            param.Add("@UserId", userId);
            var list = Dapper.Mapper.SqlMapper.Query<Order, Stock>
                (Db, "GetOrders",
                splitOn: "StockId",
                param: param,
                commandType: CommandType.StoredProcedure);
            return list;
        }
    }
}
