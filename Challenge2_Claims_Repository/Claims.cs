using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_Repository
{
    public enum ClaimType { Car = 1, Home, Theft}
    public class Claims
    {
        public Claims() { }
        public Claims(int claimID, ClaimType claimType, string descriptionOfClaim, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            claimID = ClaimID;
            claimType = TypeOfClaim;
            descriptionOfClaim = ClaimDescription;
            claimAmount = ClaimAmount;
            dateOfIncident = DateOfIncident;
            dateOfClaim = DateOfClaim;
            isValid = IsValid;
        }

        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        { 
            get
            {
                int numberOfDays = Convert.ToInt32(DateOfClaim - DateOfIncident);
                if (numberOfDays > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
