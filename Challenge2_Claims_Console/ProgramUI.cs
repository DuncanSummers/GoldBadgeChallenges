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
        private readonly ClaimsRepository _claimsRepo = new ClaimsRepository();
        public void Run()
        {
            SeedClaims();
            Menu();
        }

        private void SeedClaims()
        {

        }

        private void Menu()
        {
            bool viewingMenu = true;
            while (viewingMenu)
            {
                Console.WriteLine("Welcome to Komodo Insurance Claims Department\n\n" +
                    "Menu:\n\n" +
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

            List<Claims> claimsList = _claimsRepo.ReadAllClaims();

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

            Console.WriteLine("DateOfAccident: ");

            Console.WriteLine("DateOfClaim: ");

            
            

        }
    }
}
