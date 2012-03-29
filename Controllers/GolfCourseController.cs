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
    public class GolfCourseController : Controller
    {
        private GBContext db = new GBContext();

        //
        // GET: /GolfCourse/

        public ViewResult Index()
        {
            var golfcourses = db.GolfCourses.Include(g => g.GolfClub);
            var golfClubs = new SelectList(db.GolfClubs,"GolfClubID","Name");
            ViewBag.GolfClubs = golfClubs;
            return View(golfcourses );
        }

        public PartialViewResult GolfCoursesPartial(int GolfClubID)
        {
            return PartialView(db.GolfCourses.Where(c => c.GolfClubID == GolfClubID )
                .OrderBy(c => c.Name).ToList());

        }


        //
        // GET: /GolfCourse/Details/5

        public ViewResult Details(int id)
        {
            GolfCourse golfcourse = db.GolfCourses.Find(id);
            return View(golfcourse);
        }

        //
        // GET: /GolfCourse/Create

        public ActionResult Create()
        {
            ViewBag.GolfClubID = new SelectList(db.GolfClubs, "GolfClubID", "Name");
            return View();
        }

        //
        // POST: /GolfCourse/Create

        [HttpPost]
        public ActionResult Create(GolfCourse golfcourse)
        {
            if (ModelState.IsValid)
            {
                db.GolfCourses.Add(golfcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GolfClubID = new SelectList(db.GolfClubs, "GolfClubID", "Name", golfcourse.GolfClubID);
            return View(golfcourse);
        }

        //
        // GET: /GolfCourse/Edit/5

        public ActionResult Edit(int id)
        {
            GolfCourse golfcourse = db.GolfCourses.Find(id);
            ViewBag.GolfClubID = new SelectList(db.GolfClubs, "GolfClubID", "Name", golfcourse.GolfClubID);
            return View(golfcourse);
        }

        //
        // POST: /GolfCourse/Edit/5

        [HttpPost]
        public ActionResult Edit(GolfCourse golfcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golfcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GolfClubID = new SelectList(db.GolfClubs, "GolfClubID", "Name", golfcourse.GolfClubID);
            return View(golfcourse);
        }

        //
        // GET: /GolfCourse/Delete/5

        public ActionResult Delete(int id)
        {
            GolfCourse golfcourse = db.GolfCourses.Find(id);
            return View(golfcourse);
        }

        //
        // POST: /GolfCourse/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GolfCourse golfcourse = db.GolfCourses.Find(id);
            db.GolfCourses.Remove(golfcourse);
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