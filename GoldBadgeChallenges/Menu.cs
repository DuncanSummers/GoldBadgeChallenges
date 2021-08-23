using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    public class Menu
    {
        public Dictionary<string, decimal> _items = new Dictionary<string, decimal>
        {
            { "Burger", 35.00m},
            { "Chicken", 28.50m},
            { "Oysters", 23.00m},
            { "Roasted Duck", 45.00m },
            { "Milkshake", 12.00m },
            { "Cheesecake", 18.00m }
        };

        public Menu (int num, string meal, string descr, string ingr, decimal prices )
        {
            MealNumber = num;
            MealName = meal;
            MealDescription = descr;
            MealIngredients = ingr;
            MealPrice = prices;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public decimal MealPrice { get; set; }
    }
}
