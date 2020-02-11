using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public decimal Prise { get; set; }
        public bool IsFavourite { get; set; }
        public bool available { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
