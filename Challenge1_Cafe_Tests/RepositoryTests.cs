using Challenge1_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1_Cafe_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private MenuRepository _menus;
        private Menu _items;


        [TestInitialize]
        public void Arrange()
        {
            _menus = new MenuRepository();
            _items = new Menu(1, "Ribeye", "Center-cut, seasoned and broiled to perfection", "Ribeye steak, ground pepper, salt, thyme, garlic", 45.00m);
            _menus.AddMenuItem(_items);
        }
        
        [TestMethod]
        public void AddMenu_ShouldReturnTrue()
        {
            MenuRepository menu = new MenuRepository();
            Menu meal = new Menu();

            meal.MealName = "Ribeye";
            bool wasAdded = menu.AddMenuItem(meal);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void ReadMenu_ShouldReturnTrue()
        {
            MenuRepository menu = new MenuRepository();
            Menu meal = new Menu();
            meal.MealName = "Ribeye";

            menu.AddMenuItem(meal);

            List<Menu> newMeal = menu.ReadMenu();

            bool menuHasMeal = newMeal.Contains(meal);
            Assert.IsTrue(menuHasMeal);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            bool deleteMeal = _menus.DeleteMenuItem(_items.MealName);
            Assert.IsTrue(deleteMeal);
        }
    }
}
