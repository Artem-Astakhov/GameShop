using GameShop.Models;
using GameShop.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class CartController:Controller
    {
        GameContext context;
        Cart cart;

        public CartController(GameContext context, Cart cart)
        {
            this.context = context;
            this.cart = cart;
        }

        public ActionResult Index()
        {
            var item = cart.GetItems();
            cart.CartItems = item;

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
    }
}
