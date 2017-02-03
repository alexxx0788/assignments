using System;
using ShepherdCoAPI.Shared.Attributes;
using ShepherdCoAPI.Shared.Dto;

namespace ShepherdCoAPI.Model
{
    public class Order:IDto
    {
        [PrimaryKey]
        public int OrderId { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

    }
}
