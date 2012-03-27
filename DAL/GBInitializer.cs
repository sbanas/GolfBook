using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GB.Models;


namespace GB.DAL
{
    //DropCreateDatabaseIfModelChanges<GBContext>

    public class GBInitializer : DropCreateDatabaseAlways <GBContext>
    {
        protected override void Seed(GBContext context)
        {
            var golfClubs = new List<GolfClub>
            {
                new GolfClub{Name = "A&A Golf Club"},
                new GolfClub{Name = "Amber Baltic Golf Club"},
                new GolfClub{Name = "Augustowski Klub Golfa"},
                new GolfClub{Name = "Binowo Park Golf Club "},
                new GolfClub{Name = "City Golf Wrocław"},
                new GolfClub{Name = "Euler Hermes City Golf"},
                new GolfClub{Name = "First Wrocław Golf Club "},
                new GolfClub{Name = "Gdańsk Golf & Country Club"},
                new GolfClub{Name = "Gliwicki Klub Golfowy"},
                new GolfClub{Name = "Golf Club Bytkowo"},
                new GolfClub{Name = "Golf Club Pszczyna"},
                new GolfClub{Name = "Golf Palace & Country Club"},
                new GolfClub{Name = "Golf Park Gdynia Club"},
                new GolfClub{Name = "Golf Swing Józefów"},
                new GolfClub{Name = "Golfstok Białystok"},
                new GolfClub{Name = "Gorzowski Klub Golfowy"},
                new GolfClub{Name = "Głogów Golf Club"},
                new GolfClub{Name = "Kalinowe Pola Golf Club"},
                new GolfClub{Name = "Klub Golfowy FWG&CC"},
                new GolfClub{Name = "Klub Golfowy Komorów"},
                new GolfClub{Name = "Klub Golfowy Lisia Polana"},
                new GolfClub{Name = "Klub Golfowy Toya "},
                new GolfClub{Name = "Klub Golfowy Wierzchowiska "},
                new GolfClub{Name = "Koniński Klub Golfowy"},
                new GolfClub{Name = "Kraków Valley Golf & Country Club"},
                new GolfClub{Name = "Mazury Golf & Country Club"},
                new GolfClub{Name = "Modry Las Golf Club"},
                new GolfClub{Name = "Opolski Klub Golfowy"},
                new GolfClub{Name = "Panorama Golf Club"},
                new GolfClub{Name = "Pierwszy Akademicki Klub Golfowy"},
                new GolfClub{Name = "Pierwszy Kaliski KG"},
                new GolfClub{Name = "Pierwszy Lubelski Klub Golfowy"},
                new GolfClub{Name = "Play Golf Club"},
                new GolfClub{Name = "Podkarpacki Klub Golfowy"},
                new GolfClub{Name = "Polonia Golf Club"},
                new GolfClub{Name = "Poznań Golf Park"},
                new GolfClub{Name = "Rosa Private Golf Club"},
                new GolfClub{Name = "Royal Kraków Golf & Country Club"},
                new GolfClub{Name = "Royal Wilanów Golf Club"},
                new GolfClub{Name = "Rybnicki Klub Golfowy"},
                new GolfClub{Name = "Rycerski Klub Golfowy Krobielowice"},
                new GolfClub{Name = "Sand Valley Golf & Country Club"},
                new GolfClub{Name = "Sierra Golf Club"},
                new GolfClub{Name = "Śląski Klub Golfowy"},
                new GolfClub{Name = "Sobienie Królewskie Golf & Country Club"},
                new GolfClub{Name = "Sudecki Klub Golfowy"},
                new GolfClub{Name = "Tatfort Golf Club"},
                new GolfClub{Name = "Tokary Golf Club"},
                new GolfClub{Name = "Tower Golf Club"},
                new GolfClub{Name = "Tyski Klub Golfowy"},
                new GolfClub{Name = "Warsaw Golf Promotion"},
                new GolfClub{Name = "Wielkopolski Klub Golfowy"},
                new GolfClub{Name = "Łukęcin Golf & Relax Club"}
            };
            golfClubs.ForEach(s => context.GolfClubs.Add(s));
            context.SaveChanges();

            var golfCourses = new List<GolfCourse>{
                new GolfCourse{
                    GolfClub = golfClubs.Where(gc => (gc.Name.Equals("Gdańsk Golf & Country Club"))).First(),
                    Name="Academy course",
                    Description="best for starters",
                    Par=20, 
                    CourseHoles = new List<CourseHole>
                    {
                        new CourseHole { HoleNumber=1,HolePar =3,HoleLength=93,HoleHCP=13},
                        new CourseHole { HoleNumber=2,HolePar =4,HoleLength=258,HoleHCP=1},
                        new CourseHole { HoleNumber=3,HolePar =3,HoleLength=135,HoleHCP=7},
                        new CourseHole { HoleNumber=4,HolePar =3,HoleLength=141,HoleHCP=10},
                        new CourseHole { HoleNumber=5,HolePar =4,HoleLength=249,HoleHCP=4},
                        new CourseHole { HoleNumber=6,HolePar =3,HoleLength=138,HoleHCP=16}
                    }
                },
                new GolfCourse
                {
                    GolfClub = golfClubs.Where(gc => (gc.Name.Equals("Gdańsk Golf & Country Club"))).First(),
                    Name="Championship course",
                    Description="Championship course par 72.",
                    Par=72, 
                    CourseHoles = new List<CourseHole>
                    {
                        new CourseHole { HoleNumber = 1, HolePar = 4,HoleLength = 314 ,HoleHCP = 14 },
                        new CourseHole { HoleNumber = 2, HolePar = 4,HoleLength = 357 ,HoleHCP = 8 },
                        new CourseHole { HoleNumber = 3, HolePar = 3,HoleLength = 174 ,HoleHCP = 12 },
                        new CourseHole { HoleNumber = 4, HolePar = 5,HoleLength = 454 ,HoleHCP = 10 },
                        new CourseHole { HoleNumber = 5, HolePar = 4,HoleLength = 391 ,HoleHCP = 2 },
                        new CourseHole { HoleNumber = 6, HolePar = 4,HoleLength = 330 ,HoleHCP = 16 },
                        new CourseHole { HoleNumber = 7, HolePar = 5,HoleLength = 523 ,HoleHCP = 4 },
                        new CourseHole { HoleNumber = 8, HolePar = 3,HoleLength = 164 ,HoleHCP = 17 },
                        new CourseHole { HoleNumber = 9, HolePar = 5,HoleLength = 475 ,HoleHCP = 6 },
                        new CourseHole { HoleNumber = 10, HolePar = 4,HoleLength = 416 ,HoleHCP = 1 },
                        new CourseHole { HoleNumber = 11, HolePar = 3,HoleLength = 122 ,HoleHCP = 18 },
                        new CourseHole { HoleNumber = 12, HolePar = 4,HoleLength = 358 ,HoleHCP = 15 },
                        new CourseHole { HoleNumber = 13, HolePar = 4,HoleLength = 390 ,HoleHCP = 9 },
                        new CourseHole { HoleNumber = 14, HolePar = 4,HoleLength = 423 ,HoleHCP = 7 },
                        new CourseHole { HoleNumber = 15, HolePar = 4,HoleLength = 394 ,HoleHCP = 3 },
                        new CourseHole { HoleNumber = 16, HolePar = 3,HoleLength = 186 ,HoleHCP = 11 },
                        new CourseHole { HoleNumber = 17, HolePar = 4,HoleLength = 366 ,HoleHCP = 13 },
                        new CourseHole { HoleNumber = 18, HolePar = 5,HoleLength = 495 ,HoleHCP = 5 }
                    }
                },
                new GolfCourse
                {
                    GolfClub = golfClubs.Where(gc => (gc.Name.Equals("Sierra Golf Club"))).First(),
                    Name="Championship course",
                    Description="Championship course par 72.",
                    Par=72, 
                    CourseHoles = new List<CourseHole>
                    {
                        new CourseHole { HoleNumber = 1, HolePar = 4,HoleLength = 314 ,HoleHCP = 14 },
                        new CourseHole { HoleNumber = 2, HolePar = 4,HoleLength = 357 ,HoleHCP = 8 },
                        new CourseHole { HoleNumber = 3, HolePar = 3,HoleLength = 174 ,HoleHCP = 12 },
                        new CourseHole { HoleNumber = 4, HolePar = 5,HoleLength = 454 ,HoleHCP = 10 },
                        new CourseHole { HoleNumber = 5, HolePar = 4,HoleLength = 391 ,HoleHCP = 2 },
                        new CourseHole { HoleNumber = 6, HolePar = 4,HoleLength = 330 ,HoleHCP = 16 },
                        new CourseHole { HoleNumber = 7, HolePar = 5,HoleLength = 523 ,HoleHCP = 4 },
                        new CourseHole { HoleNumber = 8, HolePar = 3,HoleLength = 164 ,HoleHCP = 17 },
                        new CourseHole { HoleNumber = 9, HolePar = 5,HoleLength = 475 ,HoleHCP = 6 },
                        new CourseHole { HoleNumber = 10, HolePar = 4,HoleLength = 416 ,HoleHCP = 1 },
                        new CourseHole { HoleNumber = 11, HolePar = 3,HoleLength = 122 ,HoleHCP = 18 },
                        new CourseHole { HoleNumber = 12, HolePar = 4,HoleLength = 358 ,HoleHCP = 15 },
                        new CourseHole { HoleNumber = 13, HolePar = 4,HoleLength = 390 ,HoleHCP = 9 },
                        new CourseHole { HoleNumber = 14, HolePar = 4,HoleLength = 423 ,HoleHCP = 7 },
                        new CourseHole { HoleNumber = 15, HolePar = 4,HoleLength = 394 ,HoleHCP = 3 },
                        new CourseHole { HoleNumber = 16, HolePar = 3,HoleLength = 186 ,HoleHCP = 11 },
                        new CourseHole { HoleNumber = 17, HolePar = 4,HoleLength = 366 ,HoleHCP = 13 },
                        new CourseHole { HoleNumber = 18, HolePar = 5,HoleLength = 495 ,HoleHCP = 5 }
                    }
                }
            };
            golfCourses.ForEach(g => context.GolfCourses.Add(g));
            context.SaveChanges();


            //var games = new List<Game>
            //{
            //    new Game { 
            //        Date = System.DateTime.Parse("2012-03-25 11:00"), 
            //        GolfCourse = golfCourses[0], 
            //        Marker = "sbanas", 
            //        Rounds=1
            //    }
            //};
            //games.ForEach(g => context.Games.Add(g));


            var userClubs = new List<UserClub> 
            {
                new UserClub {UserName="sbanas",Brand="Wilson DI9",Name="Sand Wedge"},
                new UserClub {UserName="sbanas",Brand="Wilson DI9",Name="Pitch Wedge"},
                new UserClub {UserName="sbanas",Brand="Wilson DI9",Name="9 Iron"},
                new UserClub {UserName="sbanas",Brand="Wilson DI9",Name="8 Iron"},
                new UserClub {UserName="sbanas",Brand="Wilson DI9",Name="7 Iron"},
                new UserClub {UserName="sbanas",Brand="Wilson DI9",Name="6 Iron"},
                new UserClub {UserName="sbanas",Brand="Wilson DI9",Name="5 Iron"},
                new UserClub {UserName="sbanas",Brand="Wilson",Name="FY Hybrid"},
                new UserClub {UserName="sbanas",Brand="Wilson",Name="3 Wood"},
                new UserClub {UserName="sbanas",Brand="Ben Sayers",Name="Putter"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="Sand Wedge"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="Pitch Wedge"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="9 Iron"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="8 Iron"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="7 Iron"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="6 Iron"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="5 Iron"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="Hybrid"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="3 Wood"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="Driver"},
                new UserClub {UserName="test",Brand="Taylor Made",Name="Putter"}
            };

            userClubs.ForEach(s => context.UserClubs.Add(s));

            context.SaveChanges();
        }

        //golfClubs.Where(



        private byte[] LoadImage(string FileName)
        {
            byte[] buffer = null;
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long totalBytes = new FileInfo(FileName).Length;

                buffer = br.ReadBytes((Int32)totalBytes);

                fs.Close();
                fs.Dispose();
                br.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return buffer;
        }
    }
}