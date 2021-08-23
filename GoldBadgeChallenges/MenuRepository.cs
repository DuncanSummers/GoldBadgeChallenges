using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe_Repository
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
        public List<Menu> ReadMenu()
        {
            return _menus;
        }

        public Menu ReadMenuItem(string meal)
        {
            foreach (Menu menu in _menus)
            {
                if (menu.MealName == meal)
                {
                    return menu;
                }
            }

            return null;
        }
        public bool DeleteMenuItem(string meal)
        {
            Menu menu = ReadMenuItem(meal);

            if(menu == null)
            {
                return false;
            }

            int startingCount = _menus.Count;
            _menus.Remove(menu);

            if(startingCount > _menus.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
