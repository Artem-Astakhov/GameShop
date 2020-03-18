using GameShop.Models;
using GameShop.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace GameShop.Controllers
{
    public class AdminController:Controller
    {
        GameContext context;
        IWebHostEnvironment hostEnvironment;

        public AdminController(GameContext context, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.hostEnvironment = hostEnvironment;
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

        public IActionResult GetGames()
        {
            AdminModel obj = new AdminModel(context);
            return View(obj);
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            AddGameModel obj = new AddGameModel(context);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(AddGameModel model, IFormFile uploadedFile)
        {
            if (ModelState.IsValid && uploadedFile != null)
            {
                string path = "/img/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(hostEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                context.Games.Add(
                    new Game
                    {
                        Name = model.Name,
                        ShortDescription = model.ShortDescription,
                        LongDescription = model.LongDescription,
                        Image = path,
                        Prise = model.Prise,
                        IsFavourite = model.IsFavourite,
                        available = model.available,
                        CategoryId = model.Category
                    });
                await context.SaveChangesAsync();
                return RedirectToAction("GetGames");
            }
            else ModelState.AddModelError("", "Ошибка");

            return View(new AddGameModel(context));
        }
    }
}
