using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GB.Models
{
    public class GameHit
    {
        public int GameHitID { get; set; }
        public int GameHoleID { get; set; }
        public int GameHitNo { get; set; }
        public int UserClubID { get; set; }



        public virtual UserClub UserClub { get; set; }
        public virtual GameHole GameHole { get; set; }
    }
}