using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class CreateOrder
    {
        readonly GameContext context;
        readonly Cart cart;

        public CreateOrder(GameContext context, Cart cart)
        {
            this.cart = cart;
            this.context = context;
        }

        public void Create(Order order)
        {
            order.OrderTime = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();

            var items = cart.CartItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    GameId = el.Game.GameId,
                    GameName = el.Game.Name,
                    Price = el.Game.Prise,
                    OrderId = order.Id
                };
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
        }
    }
}
