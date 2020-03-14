using GameShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.ViewsModels
{
    public class AdminModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        GameContext context;
        
        public AdminModel()
        {

        }
        public AdminModel(GameContext context)
        {
            this.context = context;
            GetGames = context.Games.ToList();
            GetUsers = context.Users.ToList();
            GetOrders = context.OrderDetails.ToList();
        }

        public List<User> GetUsers { get; set; }
        public List<Game> GetGames { get; set; }
        public List<OrderDetail> GetOrders { get; set; }
        

        
        
        
    }
}
