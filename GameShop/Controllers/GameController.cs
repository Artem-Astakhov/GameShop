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
        GameContext db;
        public GameController(GameContext context)
        {
            db = context;
        }
        public IActionResult List()
        {
            ViewBag.Title = "Настольные игры";
            GamesViewCategory obj = new GamesViewCategory(db);
            obj.CurrentCategory = "Амери";
            
            return View(obj);
        }
       
    }
}
