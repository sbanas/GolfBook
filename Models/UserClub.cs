using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GB.Models
{
    public class UserClub
    {
        public int UserClubID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}