using Challenge1_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge1_Cafe_Console
{
    public class ProgramUI
    {
        private readonly MenuRepository _menu = new MenuRepository();
        public void Run()
        {
            SeedMenu();
            Menus();
        }

        private void SeedMenu()
        {
            Console.WriteLine("Seeding menu...");

            Menu meal1 = new Menu(1, "Burger", "Flame-broiled burger made the Komodo way", "brioche bun, ground meat, ground pepper, salt, pepperjack cheese, lettuce, onions, aioli, and mustard", 18.00m);
            Menu meal2 = new Menu(2, "Chicken", "A Whole rotisserie chicken, Nashville fried", "chicken, batter, oil", 25.00m);
            Menu meal3 = new Menu(3, "Cheese Curds", "Fresh Wisconsin cheese curds fried to golden perfection", "cheese curds, batter, oil, jalapeno-ranch", 8.50m);
            Menu meal4 = new Menu(4, "Oysters", "Half-shell East-Coast oysters on a bed of ice", "Oyster, salt, horseradish, tobasco", 21.00m);
            Menu meal5 = new Menu(5, "Corndogs", "All-American beef frank, crispy dogs", "hot dog, corn meal batter, oil, wooden stick, mustard, ketchup", 6.99m);

            _menu.AddMenuItem(meal1);
            _menu.AddMenuItem(meal2);
            _menu.AddMenuItem(meal3);
            _menu.AddMenuItem(meal4);
            _menu.AddMenuItem(meal5);

            Thread.Sleep(2000);
            Console.Clear();
        }

        private void Menus()
        {
            bool viewingMenu = true;
            while (viewingMenu)
            {
                Console.WriteLine("Welcome to Komodo Cafe!\n" +
                    "Menu:\n" +
                    "1. View Menu\n" +
                    "2. Add new menu item\n" +
                    "3. Remove menu item\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ReadMenu();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        viewingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter one of the numbers above...");
                        break;
                }

            }

            Console.Clear();
            Console.WriteLine("Logging off...");
            Thread.Sleep(2500);
        }
        public void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        public void ReadMenu()
        {
            Console.Clear();

            List<Menu> menu = _menu.ReadMenu();

            foreach (Menu meal in menu)
            {
                DisplayItem(meal);
            }

            ContinueMessage();
        }

        public void DisplayItem(Menu menu)
        {
            Console.WriteLine($"Meal #{menu.MealNumber}: {menu.MealName} - {menu.MealPrice}\n" +
                $"{menu.MealDescription}\n" +
                $"Ingredients: {menu.MealIngredients}\n");
        }

        public void AddMenuItem()
        {
            Console.Clear();
            Menu newMeal = new Menu();

            Console.Write("Meal #: ");
            int num = int.Parse(Console.ReadLine());
            newMeal.MealNumber = num;

            Console.Write("Meal Name: ");
            string meal = Console.ReadLine();
            newMeal.MealName = meal;

            Console.Write("Meal Description: ");
            string descr = Console.ReadLine();
            newMeal.MealDescription = descr;
            
            Console.Write("Meal Ingredients: ");
            string ingr = Console.ReadLine();
            newMeal.MealIngredients = ingr;

            Console.Write("Meal Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            newMeal.MealPrice = price;

            _menu.AddMenuItem(newMeal);
        }

        public void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("What meal would you like to be removed?: ");

            string meal = Console.ReadLine();

            Menu menu = _menu.ReadMenuItem(meal);
            
            if (menu == null)
            {
                Console.WriteLine("Menu item not found");
            }
            else
            {
                DisplayItem(menu);
                Console.WriteLine("Are you sure you would like to delete this from the menu? (y/n)");

                string answer = Console.ReadLine();
                if (answer.ToLower() == "y" || answer.ToLower() == "yes")
                {
                    _menu.DeleteMenuItem(meal);
                    Console.WriteLine("Item removed from menu!");
                }
                else
                {
                    Console.WriteLine("Failed to remove item...");
                }
            }

            ContinueMessage();
        }   
    }
}
