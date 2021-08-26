using Challenge3_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge3_Badges_Console
{
    public class ProgramUI
    {
        private readonly BadgesRepository _repo = new BadgesRepository();

        public void Run()
        {
            SeedingBadges();
            Menu();
        }

        private void SeedingBadges()
        {
            Console.WriteLine("Seeding badges...");

            Badges badge1 = new Badges(12345, new List<string> { "A7" });
            Badges badge2 = new Badges(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badges badge3 = new Badges(32345, new List<string> { "A4", "A5" });

            _repo.AddBadgeToRepo(badge1.BadgeID, badge1.DoorAccessList);
            _repo.AddBadgeToRepo(badge2.BadgeID, badge2.DoorAccessList);
            _repo.AddBadgeToRepo(badge3.BadgeID, badge3.DoorAccessList);

            Thread.Sleep(1500);
            Console.Clear();
        }
        
        private void Menu()
        {
            bool viewingMenu = true;
            while (viewingMenu)
            {
                Console.WriteLine("Hello Security Admin. What would you like to do?\n\n" +
                    "1. Add a badge.\n" +
                    "2. Edit a badge.\n" +
                    "3. List all badges.\n" +
                    "4. Exit.");
                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        viewingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response...");
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Logging off...");
            Thread.Sleep(1800);
        }
        public void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void AddABadge()
        {
            Console.Clear();
            

            Console.WriteLine("What is the number on the badge: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door it needs access to: ");
            List<string> doorInput = new List<string> { Console.ReadLine() };

            bool anyOtherDoors = true;
            while (anyOtherDoors)
            {
                Console.WriteLine("Any other doors?(y/n): ");
                string input = Console.ReadLine();
                if(input == "y")
                {
                    Console.WriteLine("List a door it needs access to: ");
                    string doorInput1 = Console.ReadLine();
                    doorInput.Add(doorInput1);
                }
                else if(input =="n")
                {
                    Console.WriteLine("Returning to main menu...");
                    Thread.Sleep(1500);
                    anyOtherDoors = false;
                }
                else
                {
                    Console.WriteLine("Enter either y or n\n");
                }
            }
            _repo.AddBadgeToRepo(id, doorInput);
            
            ContinueMessage();
        }

        public void EditABadge()
        {
            Console.Clear();
            bool editABadge = true;
            while (editABadge)
            {
                Console.WriteLine("What is the badge number to update?: ");
                int id = int.Parse(Console.ReadLine());
                Badges badge = _repo.GetBadgeID(id);
                Console.Write($"{badge.BadgeID} has access to door(s):");
                foreach(string door in badge.DoorAccessList)
                {
                    Console.WriteLine($" {door}");
                }
                Console.WriteLine("What would you like to do?\n\n" +
                    "1. Remove a door\n" +
                    "2. Add a door\n" +
                    "3. Exit\n");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    Console.WriteLine("Which door would you like to remove? ");
                    string doorID = Console.ReadLine();
                    _repo.DeleteSingleDoorFromBadge(badge.BadgeID, doorID);
                    
                    Console.WriteLine("Door removed");
                    Console.WriteLine($"{badge.BadgeID} has access to door(s) :");
                    foreach (string door in badge.DoorAccessList)
                    {
                        Console.WriteLine($" {door}");
                    }
                    Thread.Sleep(3500);
                    editABadge = false;
                }
                else if(input == "2")
                {
                    Console.WriteLine("Which door would you like to add? ");
                    string doorID = Console.ReadLine();
                    _repo.AddDoorsToBadge(badge.BadgeID, doorID);

                    Console.WriteLine("Door added");
                    Console.WriteLine($"{badge.BadgeID} has access to door(s):");
                    foreach (string door in badge.DoorAccessList)
                    {
                        Console.WriteLine($" {door}");
                    }
                    Thread.Sleep(3500);
                    editABadge = false;
                }
                else if(input == "3")
                {
                    Console.WriteLine("Returning to main menu...");
                    Thread.Sleep(1500);
                    editABadge = false;
                }
                else
                {
                    Console.WriteLine("Enter a valid option\n");
                }

            }
            ContinueMessage();
            
        }
        public void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> keyValuePairs = _repo.ShowBadges();
            foreach (var entry in keyValuePairs)
            {
                int key = entry.Key;
                List<string> values = entry.Value;
                Console.Write(key);
                foreach (var value in values)
                {
                    Console.Write($" {value}");
                }
                Console.WriteLine("\n");
            }
            
            ContinueMessage();
        }
    }
}
