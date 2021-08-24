using Challenge2_Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge2_Claims_Console
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _claims = new ClaimsRepository();
        public void Run()
        {
            ClaimsQueue();
            Menu();
        }

        private void ClaimsQueue()
        {
            Console.WriteLine("Seeding queue...");

            Claims claim1 = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 1, 18));

            _claims.AddNewClaim(claim1);
            _claims.AddNewClaim(claim2);
            _claims.AddNewClaim(claim3);
 
            Thread.Sleep(1800);
            Console.Clear();
        }

        private void Menu()
        {
            bool viewingMenu = true;
            while (viewingMenu)
            {
                Console.WriteLine("Welcome to Komodo Insurance Claims Department\n\n" +
                    "Choose a menu item:\n\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
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
        public void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claims> claimsList = _claims.ReadAllClaims();

            foreach (Claims claim in claimsList)
            {
                DisplayClaim(claim);
            }

            ContinueMessage();
        }
        public void DisplayClaim(Claims claimItem)
        {
            Console.WriteLine($"ClaimID: {claimItem.ClaimID} | Type: {claimItem.TypeOfClaim} | Description: {claimItem.ClaimDescription} | Amount: {claimItem.ClaimAmount} | DateOfAccident: {claimItem.DateOfIncident} | DateOfClaim: {claimItem.DateOfClaim} | IsValid: {claimItem.IsValid}");
        }

        public void TakeCareOfNextClaim()
        {
            
            Console.Clear();
            bool viewingQueue = true;
            while (viewingQueue)
            {
                Console.WriteLine("Here are the details for the next claim to be handled: ");
                Claims claimObject = _claims.GrabNextClaim();
                Console.WriteLine($"ClaimID: {claimObject.ClaimID} | Type: {claimObject.TypeOfClaim} | Description: {claimObject.ClaimDescription} | Amount: {claimObject.ClaimAmount} | DateOfAccident: {claimObject.DateOfIncident} | DateOfClaim: {claimObject.DateOfClaim} | IsValid: {claimObject.IsValid}");
                
                Console.WriteLine("Do you want to deal with this claim now(y/n)?");
               
                string input = Console.ReadLine();
                if (input == "y")
                {
                    _claims.DequeueExistingClaim();
                }
                else if (input == "n")
                {
                    viewingQueue = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid reponse...");
                }
            }
            Console.Clear();
            Console.WriteLine("Returning to menu...");
            Thread.Sleep(1800);
        }


        public void EnterNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("ClaimId: ");
            int id = int.Parse(Console.ReadLine());
            newClaim.ClaimID = id;

            Console.WriteLine("ClaimType\n" +
                "'1' for Car\n" +
                "'2' for Home\n" +
                "'3' for Theft\n");
            Console.Write("Type of Claim: ");
            string typeInput = Console.ReadLine();
            int typeID = int.Parse(typeInput);
            newClaim.TypeOfClaim = (ClaimType)typeID;

            Console.WriteLine("Description: ");
            string descrtiptionOfClaim = Console.ReadLine();
            newClaim.ClaimDescription = descrtiptionOfClaim;

            Console.WriteLine("Amount: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            newClaim.ClaimAmount = claimAmount;

            Console.WriteLine("DateOfAccident(yyyy/mm/dd): ");
            DateTime dateOfIncident = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfIncident = dateOfIncident;

            Console.WriteLine("DateOfClaim(yyyy/mm/dd): ");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfClaim = dateOfClaim;

            Console.WriteLine(newClaim.IsValid);

            _claims.AddNewClaim(newClaim);
            
        }
    }
}
