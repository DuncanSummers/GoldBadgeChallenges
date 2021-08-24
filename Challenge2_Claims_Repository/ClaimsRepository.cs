using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_Repository
{
    public class ClaimsRepository
    {
        protected readonly List<Claims> _claimsRepo = new List<Claims>();

        public bool AddNewClaim(Claims newClaim)
        {
            int startingCount = _claimsRepo.Count;
            _claimsRepo.Add(newClaim);
            bool wasAdded = _claimsRepo.Count > startingCount;
            return wasAdded;
        }
        public List<Claims> ReadAllClaims()
        {
            return _claimsRepo;
        }

        public Claims ReadSpecificClaim(int claimID)
        {
            foreach (Claims newClaim in _claimsRepo)
            {
                if (newClaim.ClaimID == claimID)
                {
                    return newClaim;
                }
            }
            return null;
        }
        public bool UpdateExistingClaim(int originalID, Claims updatedClaim)
        {
            Claims oldClaim = ReadSpecificClaim(originalID);
            
            if (oldClaim != null)
            {
                oldClaim.ClaimID = updatedClaim.ClaimID;
                oldClaim.TypeOfClaim = updatedClaim.TypeOfClaim;
                oldClaim.ClaimDescription = updatedClaim.ClaimDescription;
                oldClaim.ClaimAmount = updatedClaim.ClaimAmount;
                oldClaim.DateOfIncident = updatedClaim.DateOfIncident;
                oldClaim.DateOfClaim = updatedClaim.DateOfClaim;

                return true;
            }
            return false;
        }

        public bool DeleteExistingClaim(int existingClaim)
        {
            Claims claim = ReadSpecificClaim(existingClaim);

            if (claim == null)
            {
                return false;
            }

            int startingCount = _claimsRepo.Count;
            _claimsRepo.Remove(claim);

            if (startingCount > _claimsRepo.Count)
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
