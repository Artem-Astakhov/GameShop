using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.ViewsModels
{
    public class GamesViewCategory
    {
        GameContext context;
        public GamesViewCategory(GameContext context)
        {
            this.context = context;
            GetGames = context.Games.ToList();
        }
        public List <Game> GameCategory { get; set; }
        public List<Game> GetGames { get; set; }
        public string CurrentCategory { get; set; }
    }
}
