using GameShop.Models;
using GameShop.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class CartController:Controller
    {
        readonly GameContext context;
        readonly Cart cart;

        public CartController(GameContext context, Cart cart)
        {
            this.context = context;
            this.cart = cart;
        }

        public IActionResult Index()
        {
            var obj = new CartViewModel
            {
                Cart = cart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = context.Games.FirstOrDefault(i => i.GameId == id);

            if (item != null)
            {
                cart.AddItem(item);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            var item = context.Games.Where(i => i.GameId == id).FirstOrDefault();
            if (item != null)
            {
                cart.RemoveLine(item);
            }
            return RedirectToAction("index");
        }

    }
}
