using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GB.Models
{
    public class CourseHole
    {
        public int CourseHoleID { get; set; }
        public int GolfCourseID { get; set; }

        [Display(Name="Hole Number")]
        public int HoleNumber { get; set; }

        [Display(Name="PAR")]
        [Range(3,5)]
        public int HolePar { get; set; }

        [Display(Name="Lenght (m)")]
        [Range(0,1000)]
        public int HoleLength { get; set; }

        [Display(Name="Hole HCP")]
        [Range(1,56)]
        public int HoleHCP { get; set; }

        [Display(Name="Description")]
        [DataType(DataType.MultilineText)]
        public string HoleDescription { get; set; }

        public virtual GolfCourse GolfCourse {get;set;}
        public virtual ICollection<GameHole> GameHoles{ get; set; }

    }
}