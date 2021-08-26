using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badges_Repository
{
    public class BadgesRepository
    {
        protected readonly Dictionary<int, List<string>> _badgeAccessRepo = new Dictionary<int, List<string>>();


        public bool AddBadgeToRepo(int id, List<string> doors)
        {
            int initial = _badgeAccessRepo.Count();
            _badgeAccessRepo.Add(id, doors);
            return _badgeAccessRepo.Count() > initial;
        }


        public bool AddDoorsToBadge(int badgeID, string door)
        {
            int initial = _badgeAccessRepo[badgeID].Count();
            _badgeAccessRepo[badgeID].Add(door);
            return _badgeAccessRepo[badgeID].Count () > initial;
        }


        public bool DeleteSingleDoorFromBadge(int badgeID, string door)
        {
            int initial = _badgeAccessRepo[badgeID].Count();
            _badgeAccessRepo[badgeID].Remove(door);
            return _badgeAccessRepo[badgeID].Count() < initial;
        }



        public Dictionary<int, List<string>> ShowBadges()
        {
            return _badgeAccessRepo;
        }

        public Badges GetBadgeID(int id)
        {
            Badges badge = new Badges();
            foreach (var keyValuePair in _badgeAccessRepo)
            {
                if (keyValuePair.Key == id)
                {
                    badge.BadgeID = id;
                    badge.DoorAccessList = keyValuePair.Value;
                    return badge;
                }
            }
            return null;
        }
    }
}
