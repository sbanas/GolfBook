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
        public int HolePar { get; set; }
        public int HoleLength { get; set; }
        public int HoleHCP { get; set; }
        public string HoleDescription { get; set; }

        public virtual GolfCourse GolfCourse {get;set;}
    }
}