using GameShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.ViewsModels
{
    public class AddGameModel
    {

        GameContext context;
        public AddGameModel()
        {

        }
        public AddGameModel(GameContext context)
        {
            this.context = context;
            GetGames = context.Games.Include("Category").ToList();
        }
        public List<Game> GetGames { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public decimal Prise { get; set; }
        public bool IsFavourite { get; set; }
        public bool available { get; set; }
        public int Category { get; set; }
    }
}
