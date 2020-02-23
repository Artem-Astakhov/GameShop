using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.ViewsModels
{
    public class HomeViewModel
    {
        GameContext context;
        public HomeViewModel(GameContext context)
        {
            this.context = context;
            GetFavGames = context.Games.Where(g => g.IsFavourite == true).ToList();
        }
        public List<Game> GetFavGames { get; set; }
    }
}
