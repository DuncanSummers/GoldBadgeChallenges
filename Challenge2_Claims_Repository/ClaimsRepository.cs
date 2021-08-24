using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_Repository
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claims> _claimsRepo = new Queue<Claims>();

        public bool AddNewClaim(Claims newClaim)
        {
            int startingCount = _claimsRepo.Count;
            _claimsRepo.Enqueue(newClaim);
            bool wasAdded = _claimsRepo.Count > startingCount;
            return wasAdded;
        }
        public Queue<Claims> ReadAllClaims()
        {
            return _claimsRepo;
        }

        public Claims GrabNextClaim()
        {
            return _claimsRepo.Peek();
        }

        public bool DequeueExistingClaim()
        {
            int startingCount = _claimsRepo.Count;
            _claimsRepo.Dequeue();

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
