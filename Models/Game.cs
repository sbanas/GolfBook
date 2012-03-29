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

        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        
        public string Marker { get; set; }
        //public string PlayerA { get; set; }
        //public string PlayerB { get; set; }
        //public string PlayerC { get; set; }

        [Display(Name="No of Rounds")]
        [Range(1,5)]
        public int Rounds { get; set; }

        [Display(Name="Description",
            Description="Provide biref description of your game, conditions, wheather.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual GolfCourse GolfCourse { get; set; }

        public virtual ICollection<GameHole> GameHoles { get; set; }

    }
}