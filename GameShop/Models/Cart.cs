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
        public string CartId { get; set; }

        public List<CartItem> CartItems = new List<CartItem>();

        public virtual void AddItem(Game game)
        {
            
            CartItems.Add(
                new CartItem
                {
                    CartId = CartId,
                    Game = game,
                    Price = game.Prise
                });    
        }

        public virtual void Clear()
        {
            CartItems.Clear();           
        }

        public virtual void RemoveLine(Game game)
        {
            CartItems.RemoveAll(i => i.Game.GameId == game.GameId);
        }
    }
}
