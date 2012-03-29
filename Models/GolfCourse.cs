using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GB.Models
{
    public class GolfCourse
    {
        public int GolfCourseID { get; set; }
        public int GolfClubID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Par { get; set; }
        public virtual GolfClub GolfClub { get; set; }
        public virtual ICollection<CourseHole> CourseHoles { get; set; }
    }
}