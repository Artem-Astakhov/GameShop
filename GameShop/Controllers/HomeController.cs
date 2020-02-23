using GameShop.Models;
using GameShop.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class HomeController:Controller
    {
        GameContext context;

        public HomeController(GameContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel obj = new HomeViewModel(context);
            return View(obj);
        }
    }
}
