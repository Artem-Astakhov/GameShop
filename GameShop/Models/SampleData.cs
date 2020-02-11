using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public static class SampleData
    {
        public static void Initialize(GameContext db)
        {
            if (!db.Categories.Any())
            {
                db.Categories.AddRange(               
                    new Category
                    {
                        Name = "Америтреш",
                        Description = "Игры с рандомом и кубиками"
                    },
                    new Category
                    {
                        Name = "Стратегии",
                        Description = "Игры на контроль територий"
                    },
                    new Category
                    {
                        Name = "Для компании",
                        Description = "Веселые игры для компании"
                    }
                );
                db.SaveChanges();
                       
                db.Games.AddRange(
                    new Game
                    {
                        Name = "Древний Ужас",
                        ShortDescription = "Колективная Америтреш игра",
                        LongDescription = "Игра отправляет нас на борьбу со сверхъестественным ужасом, уже знакомым нам из повестей и рассказов Говарда Ф.Лавкрафта.",
                        Image = "https://domigr.com.ua/image/cache/data/UgasArkhema/Drevnij_ugas/01_Drevnij_ugas-501x501.jpg",
                        Prise = 1900,
                        IsFavourite = true,
                        available = true,
                        CategoryId=1
                    },
                    new Game
                    {
                        Name = "Игра престолов",
                        ShortDescription = "Игра на контроль территории для 5 игроков.",
                        LongDescription = "От трёх до шести игроков берут на себя роль великих Домов Семи Королевств Вестероса и начинают свою борьбу за контроль над Железным Троном.",
                        Image = "https://i1.rozetka.ua/goods/12739203/91719968_images_12739203572.png",
                        Prise = 1900,
                        IsFavourite = true,
                        available = true,
                        CategoryId = 2
                    },
                    new Game
                    {
                        Name = "Манчкин",
                        ShortDescription = "Это обалденная игра для всех, кто играл в РПГ, ДнД и тому подобные игры",
                        LongDescription = "Манчкин - это пародия на ролевую игру, которая позволит вам ощутить всю прелесть ползания по подземельям, но без всей этой словесной мишуры, типа, отыгрыша роли!",
                        Image = "https://s1-goods.ozstatic.by/1000/680/93/1/1093680_0.jpg",
                        Prise = 1900,
                        IsFavourite = true,
                        available = true,
                        CategoryId = 3
                    }
                );
                db.SaveChanges();
            }

        }
    }
}
