using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GB.Models;
using GB.DAL;

namespace GB.Controllers
{
    public class GameController : Controller
    {
        private GBContext db = new GBContext();

        //
        // GET: /Game/

        public ViewResult Index()
        {
            var games = db.Games
                .Where(g => g.Marker.Equals(User.Identity.Name))
                .Include(g => g.GolfCourse);
            return View(games.ToList());
        }
        public PartialViewResult GolfCoursePartial(int GolfClubID)
        {
            ViewBag.GolfCourseID =
                new SelectList(db.GolfCourses
                    .Where(c => c.GolfClubID == GolfClubID)
                    .ToList()
                    , "GolfCourseID", "Name");

            return PartialView("GolfCoursePartial", ViewBag.GolfCourseID);

        }
        //
        // GET: /Game/Details/5

        public ViewResult Details(int id)
        {
            Game game = db.Games.Find(id);
            return View(game);
        }

        //
        // GET: /Game/Create

        public ActionResult Create()
        {
            ViewBag.GolfClubID = new SelectList(db.GolfClubs.Where(g => g.GolfCourses.Count > 0), "GolfClubID", "Name");

            ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name");
            return View();
        }

        //
        // POST: /Game/Create

        [HttpPost]
        public ActionResult Create(Game game)
        {

            if (ModelState.IsValid)
            {
                game.Marker = User.Identity.Name;
                game = db.Games.Add(game);
                game.GameHoles = new List<GameHole>();
                for (int r = 1; r <= game.Rounds; r++)
                {
                    foreach (var hole in db.GolfCourses.Find(game.GolfCourseID).CourseHoles)
                    {
                        game.GameHoles.Add(new GameHole { CourseHoleID = hole.CourseHoleID  });
                    }
                }
                db.SaveChanges();
                ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name", game.GolfCourseID);

                return RedirectToAction("Index");
            }

            ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name", game.GolfCourseID);

            return View(game);


        }

        //
        // GET: /Game/Edit/5

        public ActionResult Edit(int id)
        {
            Game game = db.Games.Find(id);
            ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name", game.GolfCourseID);
            return View(game);
        }

        //
        // POST: /Game/Edit/5

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Game/Delete/5

        public ActionResult Delete(int id)
        {
            Game game = db.Games.Find(id);
            return View(game);
        }

        //
        // POST: /Game/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}