using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public decimal Price { get; set; }       
        public string CartId { get; set; }
    }
}
