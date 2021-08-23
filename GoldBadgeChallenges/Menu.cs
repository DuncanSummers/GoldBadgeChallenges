using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe_Repository
{
    public class Menu
    {
        public Menu() { }
        public Menu (int num, string meal, string descr, string ingr, decimal price )
        {
            MealNumber = num;
            MealName = meal;
            MealDescription = descr;
            MealIngredients = ingr;
            MealPrice = price;
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public decimal MealPrice { get; set; }
    }
}
