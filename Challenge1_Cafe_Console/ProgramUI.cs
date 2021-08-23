using GoldBadgeChallenges;
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
            Menu();
        }
        public void Menu()
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

            foreach (Menu menu in menu)
            {
                return DipslayItem(menu);
            }

            ContinueMessage();
        }

        public void DisplayItem(Menu menu)
        {
            Console.WriteLine($"Meal #{menu.MealName}: {menu.MealName} - {menu.MealPrice}\n" +
                $"{menu.MealDescription}\n" +
                $"Ingredients: {menu.MealIngredients}");
        }

        public void AddMenuItem()
        {
            Console.Clear();
            Menu menu = new Menu();

            Console.Write("Meal #: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("Meal Name: ");
            string meal = Console.ReadLine();

            Console.Write("Meal Description");
            string descr = Console.ReadLine();

            Console.Write("Meal Ingredients");
            string ingr = Console.ReadLine();

            Console.Write("Meal Price");
            double price = double.Parse(Console.ReadLine());
        }

        public void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("What menu item number would you like to be removed?: ");

            int num = int.Parse(Console.ReadLine());

            Menu menu = _menu.DeleteMenuItem(num);
            
        }
    }
}
