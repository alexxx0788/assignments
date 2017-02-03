using System.Data;
using System.Linq;
using ShepherdCoAPI.Helper;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository.Db;

namespace ShepherdCoAPI.Repository
{
    public class UserRepository : DbRepository<User>
    {
        public UserRepository(IDbConnection connection) : base(connection)
        {
            if (!base.GetList().Any())
            {
                base.Insert(DummyData.GetTestUser());
            }
        }
    }
}
