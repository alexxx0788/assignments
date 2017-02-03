using ShepherdCoAPI.Shared.Attributes;
using ShepherdCoAPI.Shared.Dto;

namespace ShepherdCoAPI.Model
{
    public class User:IDto
    {
        [PrimaryKey]
        public int UserId { get; set; }
        public string Login { get; set; }
        public double Balance { get; set; }

    }
}
