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
    public class TeamsController : Controller
    {
        private NHLContext db = new NHLContext();

        // GET: Teams
        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.Conference).Include(t => t.Division);
            return View(teams.ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            List<Player> players = db.Players.Where(p => p.Team_Id == id).ToList();

            PlayersTeams pt = new PlayersTeams();
            pt.teams = team;
            pt.players = players;
            if (team == null)
            {
                return HttpNotFound();
            }

            return View(pt);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            ViewBag.Conference_Id = new SelectList(db.Conferences, "Id", "Name");
            ViewBag.Division_Id = new SelectList(db.Divisions, "Id", "Name");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,City,Name,Points,Conference_Id,Division_Id")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Conference_Id = new SelectList(db.Conferences, "Id", "Name", team.Conference_Id);
            ViewBag.Division_Id = new SelectList(db.Divisions, "Id", "Name", team.Division_Id);
            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.Conference_Id = new SelectList(db.Conferences, "Id", "Name", team.Conference_Id);
            ViewBag.Division_Id = new SelectList(db.Divisions, "Id", "Name", team.Division_Id);
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,City,Name,Points,Conference_Id,Division_Id")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Conference_Id = new SelectList(db.Conferences, "Id", "Name", team.Conference_Id);
            ViewBag.Division_Id = new SelectList(db.Divisions, "Id", "Name", team.Division_Id);
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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
