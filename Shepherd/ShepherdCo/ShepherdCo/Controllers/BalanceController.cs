using System.Data.SqlClient;
using System.Web.Http;
using ShepherdCoAPI.Model;
using ShepherdCoAPI.Repository;

namespace ShepherdCo.Controllers
{
    public class BalanceController : ApiController
    {
        // GET api/balance
        public double Get()
        {
            UserRepository userRepository = new UserRepository(new SqlConnection(Helper.ConnectionString));
            var user=  userRepository.GetEntryById(Helper.UserId); 
            return user.Balance;
        }

        // PUT api/balance
        public void Put(int id,User user)
        {
            UserRepository userRepository = new UserRepository(new SqlConnection(Helper.ConnectionString));
            userRepository.Update(user, id); 
        }
    }
}
