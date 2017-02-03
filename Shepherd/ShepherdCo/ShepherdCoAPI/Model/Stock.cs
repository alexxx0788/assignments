using ShepherdCoAPI.Shared.Attributes;
using ShepherdCoAPI.Shared.Dto;

namespace ShepherdCoAPI.Model
{
    public class Stock:IDto
    {
        [PrimaryKey]
        public int StockId { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

    }
}
