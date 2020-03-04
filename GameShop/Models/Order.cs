using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class Order
    {
        public int Id { get; set; }
       
        [Display(Name="Введите имя")]
        [StringLength(10), MinLength(1)]
        [Required(ErrorMessage ="Имя не может быть пустым")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(10), MinLength(1)]
        [Required(ErrorMessage = "Фамилия не может быть пустой")]
        public string SurName { get; set; }

        [Display(Name = "Укажите адрес")]
        [StringLength(15), MinLength(2)]
        [Required(ErrorMessage = "Адрес не может быть меньше 2-х символов")]
        public string Adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(10), MinLength(10)]
        [Required(ErrorMessage = "Номер не может быть меньше 10 символов")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Введите почту")]
        [StringLength(20), MinLength(4)]
        [Required(ErrorMessage = "Не может быть меньше 4 символов")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
