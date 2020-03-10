using GameShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using GameShop.ViewsModels;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Controllers
{
    public class AccountController:Controller
    {
        readonly GameContext context;

        public AccountController(GameContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user =await context.Users.FirstOrDefaultAsync(i => i.Email == loginModel.Email && i.Password == loginModel.Password);
                if (user != null)
                {
                    await Authenticate(loginModel.Email);
                    return RedirectToAction("Log", "Forum");
                }
                else ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await context.Users.FirstOrDefaultAsync(i => i.Email == model.Email);
                if (user == null)
                {
                    context.Users.Add(new User 
                    { 
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password
                    });
                    await context.SaveChangesAsync();

                    await Authenticate(model.Email);
                    return RedirectToAction("Log", "Forum");
                }
                else ModelState.AddModelError("", "Данный пользователь существует");
            }
            return View(model);
        }

        private async Task Authenticate(string name)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "AplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Account");
        }

    }
}
