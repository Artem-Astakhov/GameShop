using GameShop.Models;
using GameShop.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class GameController:Controller
    {
        GameContext context;
        public GameController(GameContext context)
        {
            this.context = context;
        }
        public IActionResult List()
        {
            ViewBag.Title = "Настольные игры";
            GamesViewCategory obj = new GamesViewCategory(context);
            obj.CurrentCategory = "Все игры";
            
            return View(obj);
        }

        [Route("Game/GameCategory/{category}")]
        public IActionResult GameCategory(string category)
        {
            List<Game> games = new List<Game>();
            if (string.IsNullOrWhiteSpace(category))
            {
                games = context.Games.OrderBy(x => x.GameId).ToList();
            }
            else if(category == "amery")
            {
                games = context.Games.Where(x => x.Category.Name == "Америтреш").ToList();
            }
            else if(category == "strategy")
            {
                games = context.Games.Where(x => x.Category.Name == "Стратегии").ToList();
            }
            else if (category == "company")
            {
                games = context.Games.Where(x => x.Category.Name == "Для компании").ToList();               
            }

            GamesViewCategory obj = new GamesViewCategory(context)
            {
                GameCategory = games,
                CurrentCategory = games.Select(x=>x.Category.Name).ToString()
            };

            return View(obj);
        }

        public IActionResult GamePage(int id)
        {
            var item = context.Games.FirstOrDefault(i => i.GameId == id);
            if (item == null) return RedirectToAction("List");

            return View(item);
        }
       
    }
}
