using GoldBadgeChallenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        ReadMenu()
                        break;
                    case "2"
                        

            }
        }
    }
}
