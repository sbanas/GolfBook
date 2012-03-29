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
    public class GameHoleController : Controller
    {
        private GBContext db = new GBContext();

        //
        // GET: /GameHole/

        public ViewResult Index()
        {
            var gameholes = db.GameHoles.Include(g => g.Game).Include(c => c.CourseHole).Include(c => c.Game);
            return View(gameholes.ToList());
        }

        //
        // GET: /GameHole/Details/5

        public ViewResult Details(int id)
        {
            GameHole gamehole = db.GameHoles.Find(id);
            return View(gamehole);
        }

        //
        // GET: /GameHole/Create

        public ActionResult Create()
        {
            ViewBag.CourseHoleID = new SelectList(db.CourseHoles, "CourseHoleID", "HoleDescription");
            return View();
        } 

        //
        // POST: /GameHole/Create

        [HttpPost]
        public ActionResult Create(GameHole gamehole)
        {
            if (ModelState.IsValid)
            {
                db.GameHoles.Add(gamehole);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CourseHoleID = new SelectList(db.CourseHoles, "CourseHoleID", "HoleDescription", gamehole.CourseHoleID);
            return View(gamehole);
        }
        
        //
        // GET: /GameHole/Edit/5
 
        public ActionResult Edit(int id)
        {
            GameHole gamehole = db.GameHoles.Find(id);
            ViewBag.CourseHoleID = new SelectList(db.CourseHoles, "CourseHoleID", "HoleDescription", gamehole.CourseHoleID);
            return View(gamehole);
        }
        //
        // POST: /GameHole/Edit/5

        [HttpPost]
        public ActionResult Edit_(GameHole gamehole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamehole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Game", new { id = gamehole.GameID });
            }
            ViewBag.CourseHoleID = new SelectList(db.CourseHoles, "CourseHoleID", "HoleDescription", gamehole.CourseHoleID);
            return View(gamehole);
        }

        [HttpPost]
        public ActionResult Edit(GameHole gamehole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamehole).State = EntityState.Modified;
                db.SaveChanges();
                var _id =  db.GameHoles.Where(h => h.GameID == gamehole.GameID).Select(h => (h.GameHoleID > gamehole.GameHoleID)).Min();
                return RedirectToAction("Edit", "GameHole", new { id = _id });
            }
            ViewBag.CourseHoleID = new SelectList(db.CourseHoles, "CourseHoleID", "HoleDescription", gamehole.CourseHoleID);
            return View(gamehole);
        }

        //
        // GET: /GameHole/Delete/5
 
        public ActionResult Delete(int id)
        {
            GameHole gamehole = db.GameHoles.Find(id);
            return View(gamehole);
        }

        //
        // POST: /GameHole/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            GameHole gamehole = db.GameHoles.Find(id);
            db.GameHoles.Remove(gamehole);
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