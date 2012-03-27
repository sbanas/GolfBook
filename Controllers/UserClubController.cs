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
    public class UserClubController : Controller
    {
        private GBContext db = new GBContext();

        //
        // GET: /UserClub/

        public ViewResult Index()
        {

            return View(db.UserClubs.Where(u => u.UserName.Equals(User.Identity.Name) ));
        }

        //
        // GET: /UserClub/Details/5

        public ViewResult Details(int id)
        {
            UserClub userclub = db.UserClubs.Find(id);
            return View(userclub);
        }

        //
        // GET: /UserClub/Create

        public ActionResult Create()
        {

            return View();
        } 

        //
        // POST: /UserClub/Create

        [HttpPost]
        public ActionResult Create(UserClub userclub)
        {
            if (ModelState.IsValid)
            {
                userclub.UserName = User.Identity.Name;
                db.UserClubs.Add(userclub);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(userclub);
        }
        
        //
        // GET: /UserClub/Edit/5
 
        public ActionResult Edit(int id)
        {
            UserClub userclub = db.UserClubs.Find(id);
            return View(userclub);
        }

        //
        // POST: /UserClub/Edit/5

        [HttpPost]
        public ActionResult Edit(UserClub userclub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userclub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userclub);
        }

        //
        // GET: /UserClub/Delete/5
 
        public ActionResult Delete(int id)
        {
            UserClub userclub = db.UserClubs.Find(id);
            return View(userclub);
        }

        //
        // POST: /UserClub/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            UserClub userclub = db.UserClubs.Find(id);
            db.UserClubs.Remove(userclub);
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