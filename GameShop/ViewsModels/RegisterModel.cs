using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.ViewsModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Не указан електронный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Не указан пароль")]
        public string ConfirmPassword { get; set; }
    }
}
