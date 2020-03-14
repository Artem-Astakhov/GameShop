using GameShop.Models;
using GameShop.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class AdminController:Controller
    {
        GameContext context;

        public AdminController(GameContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AdminModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = context.Admin.FirstOrDefault(a => a.Name == model.Name && a.Password == model.Password);
                if (admin != null)
                {
                    return RedirectToAction("Adminka");
                }
                else ModelState.AddModelError("", "Не корректные данные");
            }
            return View(model);                       
        }

        public IActionResult Adminka()
        {
            return View();
        }

        public IActionResult GetUser()
        {
            AdminModel obj = new AdminModel(context);
            return View(obj);
        }
    }
}
