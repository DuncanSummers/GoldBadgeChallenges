using Challenge3_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3_Badges_Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private BadgesRepository _repo;
        private Badges _class;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepository();
            _class = new Badges(1234);
            _class.DoorAccessList = new List<string> { "A1", "A2" };
            _repo.AddBadgeToRepo(_class);
        }

        [TestMethod]
        public void AddNewBadge_ShouldReturnTrue()
        {
            BadgesRepository repo = new BadgesRepository();
            Badges badges = new Badges();
            List<string> door = new List<string>() {"A2"};
            badges.BadgeID = 11111;
            door.Add("A1");
            

            bool addResult = repo.AddBadgeToRepo(badges);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void AddDoorsToBadge_ShouldReturnTrue()
        {

            string accessList =  "A9";
            

            bool success = _repo.AddDoorsToBadge(1234, accessList);
            

            Assert.IsTrue(success);
        }

        [TestMethod]
        public void DeleteDoorFromBadge_ShouldReturnTrue()
        {

            bool deleteResult = _repo.DeleteSingleDoorFromBadge(1234, "A1");

            Assert.IsTrue(deleteResult);
        }


        [TestMethod]
        public void ShowAllBadges_CollectionShouldContainBadges()
        {
            //arrange
            BadgesRepository repo = new BadgesRepository();
            Badges badge1 = new Badges(1234, new List<string> { "A1", "A2" });
            //act
            repo.AddBadgeToRepo(badge1);
            Dictionary<int, List<string>> badges = repo.ShowBadges();
            //assert
            Assert.IsNotNull(badges);
        }
    }
}
