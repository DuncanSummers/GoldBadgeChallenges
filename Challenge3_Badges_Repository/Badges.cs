using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badges_Repository
{
    
    public class Badges
    {
        public Badges() { }
        public Badges (int id, List<string> door)
        {
            BadgeID = id;
            DoorID = door;
        }
        public int BadgeID { get; set; }
        public List<string> DoorID { get; set; }
    }
}
