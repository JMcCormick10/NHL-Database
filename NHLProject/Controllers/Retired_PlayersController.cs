using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NHLProject.Models;

namespace NHLProject.Controllers
{
    public class Retired_PlayersController : Controller
    {
        private NHLContext db = new NHLContext();

        // GET: Retired_Players
        public ActionResult Index()
        {
            return View(db.Retired_Players.ToList());
        }

        // GET: Retired_Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retired_Players retired_Players = db.Retired_Players.Find(id);
            if (retired_Players == null)
            {
                return HttpNotFound();
            }
            return View(retired_Players);
        }

        // GET: Retired_Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Retired_Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Position,Number,Goals,Assists,City,Team_Name")] Retired_Players retired_Players)
        {
            if (ModelState.IsValid)
            {
                db.Retired_Players.Add(retired_Players);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retired_Players);
        }

        // GET: Retired_Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retired_Players retired_Players = db.Retired_Players.Find(id);
            if (retired_Players == null)
            {
                return HttpNotFound();
            }
            return View(retired_Players);
        }

        // POST: Retired_Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Position,Number,Goals,Assists,City,Team_Name")] Retired_Players retired_Players)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retired_Players).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retired_Players);
        }

        // GET: Retired_Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retired_Players retired_Players = db.Retired_Players.Find(id);
            if (retired_Players == null)
            {
                return HttpNotFound();
            }
            return View(retired_Players);
        }

        // POST: Retired_Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Retired_Players retired_Players = db.Retired_Players.Find(id);
            db.Retired_Players.Remove(retired_Players);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
