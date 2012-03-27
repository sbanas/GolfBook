using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GB.Models
{
    public class GolfClub
    {
        public int GolfClubID { get; set; }
        public string Name { get; set; }

        [Column(TypeName ="image")]
        public byte[] Logo { get; set; }
        
        public virtual ICollection<GolfCourse> GolfCourses { get; set; }
        
    }
}