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
    public class GolfClubController : Controller
    {
        private GBContext db = new GBContext();

        //
        // GET: /GolfClub/

        public ViewResult Index()
        {
            return View(db.GolfClubs.ToList());
        }

        //
        // GET: /GolfClub/Details/5

        public ViewResult Details(int id)
        {
            GolfClub golfclub = db.GolfClubs.Find(id);
            return View(golfclub);
        }

        //
        // GET: /GolfClub/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /GolfClub/Create

        [HttpPost]
        public ActionResult Create(GolfClub golfclub)
        {
            if (ModelState.IsValid)
            {
                db.GolfClubs.Add(golfclub);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(golfclub);
        }
        
        //
        // GET: /GolfClub/Edit/5
 
        public ActionResult Edit(int id)
        {
            GolfClub golfclub = db.GolfClubs.Find(id);
            return View(golfclub);
        }

        //
        // POST: /GolfClub/Edit/5

        [HttpPost]
        public ActionResult Edit(GolfClub golfclub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golfclub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(golfclub);
        }

        //
        // GET: /GolfClub/Delete/5
 
        public ActionResult Delete(int id)
        {
            GolfClub golfclub = db.GolfClubs.Find(id);
            return View(golfclub);
        }

        //
        // POST: /GolfClub/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GolfClub golfclub = db.GolfClubs.Find(id);
            db.GolfClubs.Remove(golfclub);
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