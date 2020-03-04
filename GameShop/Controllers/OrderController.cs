using GameShop.Models;
using GameShop.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Controllers
{
    public class OrderController:Controller
    {
        readonly GameContext context;
        readonly Cart cart;
        

        public OrderController(GameContext context, Cart cart)
        {
            this.context = context;
            this.cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var createOrder = new CreateOrder(context, cart);
            cart.CartItems = cart.GetItems();
            if (cart.CartItems == null)
            {
                ModelState.AddModelError("", "Товары не добавлены");
            }

            if (ModelState.IsValid)
            {
                createOrder.Create(order);
                return RedirectToAction("Complite", order);
            }
            return View(order);
        }

        public IActionResult Complite(Order order)
        {
            ViewBag.Message = "Заказ успешно создан";
            return View(order);
        }

        public IActionResult ClearCart()
        {
           
            return RedirectToAction("Index", "Home");
        }
    }   
}
