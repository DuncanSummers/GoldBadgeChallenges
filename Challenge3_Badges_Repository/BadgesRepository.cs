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

        public bool CreateNewBadge(int badge, List<string> door)
        {
            int initial = _badgeAccessRepo.Count();
            _badgeAccessRepo.Add(badge, door);
            return _badgeAccessRepo.Count() > initial;
        }


        public bool AddDoorsToBadge(int badgeID, string door)
        {
            Badges existingBadge = GetBadgeID(badgeID);
            if (existingBadge != null)
            {
                existingBadge.DoorID.Add(door);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteAllDoorsFromBadge(int badgeID)
        {
            Badges existingBadge = GetBadgeID(badgeID);
            if (existingBadge != null)
            {
                existingBadge.DoorID.Clear();
                return true;
            }
            else
            {
                return false;
            }

        }public bool DeleteSingleDoorFromBadge(int badgeID, string door)
        {
            Badges existingBadge = GetBadgeID(badgeID);
            if (existingBadge != null)
            {
                existingBadge.DoorID.Remove(door);
                return true;
            }
            else
            {
                return false;
            }
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
                    badge.DoorID = keyValuePair.Value;
                    return badge;
                }
            }
            return null;
        }
    }
}
