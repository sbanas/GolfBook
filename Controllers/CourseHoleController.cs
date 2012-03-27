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
    public class CourseHoleController : Controller
    {
        private GBContext db = new GBContext();

        //
        // GET: /CourseHole/

        public ViewResult Index()
        {
            var courseholes = db.CourseHoles.Include(c => c.GolfCourse);
            return View(courseholes.ToList());
        }

        //
        // GET: /CourseHole/Details/5

        public ViewResult Details(int id)
        {
            CourseHole coursehole = db.CourseHoles.Find(id);
            return View(coursehole);
        }

        //
        // GET: /CourseHole/Create

        public ActionResult Create()
        {
            ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name");
            return View();
        } 

        //
        // POST: /CourseHole/Create

        [HttpPost]
        public ActionResult Create(CourseHole coursehole)
        {
            if (ModelState.IsValid)
            {
                db.CourseHoles.Add(coursehole);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name", coursehole.GolfCourseID);
            return View(coursehole);
        }
        
        //
        // GET: /CourseHole/Edit/5
 
        public ActionResult Edit(int id)
        {
            CourseHole coursehole = db.CourseHoles.Find(id);
            ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name", coursehole.GolfCourseID);
            return View(coursehole);
        }

        //
        // POST: /CourseHole/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseHole coursehole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursehole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GolfCourseID = new SelectList(db.GolfCourses, "GolfCourseID", "Name", coursehole.GolfCourseID);
            return View(coursehole);
        }

        //
        // GET: /CourseHole/Delete/5
 
        public ActionResult Delete(int id)
        {
            CourseHole coursehole = db.CourseHoles.Find(id);
            return View(coursehole);
        }

        //
        // POST: /CourseHole/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            CourseHole coursehole = db.CourseHoles.Find(id);
            db.CourseHoles.Remove(coursehole);
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