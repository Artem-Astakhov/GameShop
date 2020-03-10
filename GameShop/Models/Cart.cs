using GameShop.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class Cart
    {
        readonly GameContext context;
        CartViewModel CartViewModel = new CartViewModel();
        public Cart(GameContext context)
        {
            this.context = context;            
        }
        public string CartId { get; set; }

        public List<CartItem> CartItems = new List<CartItem>();

        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetRequiredService<GameContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new Cart(context) { CartId = cartId };
        }

        public void AddItem(Game game)
        {
            context.CartItems.Add(
                new CartItem
                {
                    CartId = CartId,
                    Game = game,
                    Price = game.Prise
                });
            context.SaveChanges();
        }

        public List<CartItem> GetItems()
        {
            return context.CartItems.Where(i => i.CartId == CartId).Include(i=>i.Game).ToList();
        }

        public void Clear()
        {
            CartItems.Clear();
            CartItems = null;
        }
    }
}
