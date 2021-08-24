using Challenge2_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge2_Claims_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private ClaimsRepository _claimsRepo;
        private Claims _claimsItems;
        
        [TestInitialize]
        public void Arrange()
        {
            _claimsRepo = new ClaimsRepository();
            _claimsItems = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            _claimsRepo.AddNewClaim(_claimsItems);
        }

        [TestMethod]
        public void AddClaim_ShouldReturnTrue()
        {
            ClaimsRepository newClaim = new ClaimsRepository();
            Claims claimID = new Claims();

            claimID.ClaimID = 1;
            bool wasAdded = newClaim.AddNewClaim(claimID);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void ReadClaim_ShouldReturnTrue()
        {
            ClaimsRepository newClaim = new ClaimsRepository();
            Claims claimID = new Claims();
            claimID.ClaimID = 2;

            newClaim.AddNewClaim(claimID);

            Queue<Claims> readClaim = newClaim.ReadAllClaims();
            
            bool newClaimHasID = readClaim.Contains(claimID);
            Assert.IsTrue(newClaimHasID);

        }

        [TestMethod]
        public void DequeueClaim_ShouldReturnTrue()
        {
            bool deleteClaim = _claimsRepo.DequeueExistingClaim();
            Assert.IsTrue(deleteClaim);
        }
    }
}
