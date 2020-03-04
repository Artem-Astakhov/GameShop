using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }

        public Game Game { get; set; }
        public Order Order { get; set; }

    }
}
