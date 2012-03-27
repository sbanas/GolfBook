using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace GB.DAL
{
    public class GBContext : DbContext
    {
        public DbSet<GolfClub> GolfClubs { get; set; }
        public DbSet<GolfCourse> GolfCourses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public DbSet<CourseHole> CourseHoles { get; set; }

        public DbSet<UserClub> UserClubs { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameHole> GameHoles { get; set; }
    }
}