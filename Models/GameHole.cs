using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace GB.Models
{
    public class GameHole
    {
        public int GameHoleID { get; set; }
        public int CourseHoleID { get; set; }

        public int TotalHits { get; set; }
        public int Putts { get; set; }

        public virtual Game Game { get; set; }
        public virtual ICollection<GameHit> GameHits { get; set; }

        public virtual CourseHole CourseHole { get; set; }
    }
}