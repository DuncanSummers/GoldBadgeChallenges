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

        [TestMethod]
        public void AddNewBadge_ShouldReturnTrue()
        {
            BadgesRepository repo = new BadgesRepository();
            Badges badges = new Badges();
            List<string> door = new List<string>() {"A2"};
            badges.BadgeID = 11111;
            door.Add("A1");
            

            bool addResult = repo.CreateNewBadge(badges.BadgeID, door);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void AddDoorsToBadge_ShouldReturnTrue()
        {
            BadgesRepository repo = new BadgesRepository();
            string door = "A1";
            int badges = 11111;

            bool addResult = repo.AddDoorsToBadge(badges, door);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void DeleteDoorFromBadge_ShouldReturnTrue()
        {
            BadgesRepository repo = new BadgesRepository();
            string door = "A1";
            int badges = 11111;

            bool deleteResult = repo.DeleteSingleDoorFromBadge(badges, door);

            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void DeleteAllFromBadge_ShouldReturnTrue()
        {
            BadgesRepository repo = new BadgesRepository();
            int badgeID = 11111;

            bool deleteResult = repo.DeleteAllDoorsFromBadge(badgeID);

            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void ShowAllBadges_ShouldReturnTrue()
        {
            BadgesRepository repo = new BadgesRepository();
            Dictionary<int, List<string>> keyValuePairs = new Dictionary<int, List<string>>();
            string door = "A1";
            int badges = 11111;

            repo.AddDoorsToBadge(badges, door);

            Dictionary<int, List<string>> keyValuePairs1 = repo.ShowBadges();

            bool dictionaryHasPairs = keyValuePairs1.ContainsKey(badges);

            Assert.IsTrue(dictionaryHasPairs);
        }

    }
}
