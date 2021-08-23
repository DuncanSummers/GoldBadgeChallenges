using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menus = new List<Menu>();

        public bool AddMenuItem(Menu menu)
        {
            int startingCount = _menus.Count;
            _menus.Add(menu);
            bool wasAdded = _menus.Count > startingCount;
            return wasAdded;
        }

        public bool DeleteMenuItem(Menu menu)
        {
            bool deleteMeal = _menus.Remove(menu);
            return deleteMeal;
        }

        public Menu ReadMenu(int num)
        {
            foreach (Menu menu in _menus)
            {
                if (menu.MealNumber == num)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}
