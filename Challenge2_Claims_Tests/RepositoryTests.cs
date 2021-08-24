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
            _claimsItems = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, DateTime{ 4 / 25 / 2018 }, DateTime{ 4 / 27 / 2018}, true);
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

            List<Claims> readClaim = newClaim.ReadAllClaims();
            
            bool newClaimHasID = readClaim.Contains(claimID);
            Assert.IsTrue(newClaimHasID);

        }

        [TestMethod]
        public void UpdateExistingContent_ShouldUpdate()
        {
            Claims updatedClaim = new Claims(1, ClaimType.Car, "Car accident on 465", 600.00m, DateTime{ 4 / 25 / 2018 }, DateTime{ 4 / 27 / 2018}, true);

            _claimsRepo.UpdateExistingClaim(1, updatedClaim);

            var expected = updatedClaim.ClaimAmount;
            var actual = _claimsRepo.ReadSpecificClaim(1).ClaimAmount;
            // var actual = _repo.GetContentByTitle("TWISTED PAIR").GenreType;
            // ​
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteClaim_ShouldReturnTrue()
        {
            bool deleteClaim = _claimsRepo.DeleteExistingClaim(_claimsItems.ClaimID);
            Assert.IsTrue(deleteClaim);
        }
    }
}
