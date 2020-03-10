using GameShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class ForumController:Controller
    {
        [Authorize]
        public IActionResult Log()
        {
            ViewBag.UserEmeil = User.Identity.Name;
            return View();
        }

    }
}
