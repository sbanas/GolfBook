using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GB.Models
{
    public class Game
    {
        public int GameID { get; set; }

        public int GolfCourseID { get; set; }

        //[DisplayFormat(DataFormatString="{0:yyyy/MM/dd HH:mm}")]
        public DateTime Date { get; set; }

        
        public string Marker { get; set; }
        //public string PlayerA { get; set; }
        //public string PlayerB { get; set; }
        //public string PlayerC { get; set; }

        public int Rounds { get; set; }
        public string Description { get; set; }

        public virtual GolfCourse GolfCourse { get; set; }

        public virtual ICollection<GameHole> GameHoles { get; set; }

    }
}