using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Talker.Models;

namespace Talker.Controllers
{
    public class TalksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Talks
        public ActionResult Index()
        {
            return View(db.Talks.ToList());
        }

        // GET: Talks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = db.Talks.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // GET: Talks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TalkID,TalkContent,timestamp")] Talk talk)
        {
            talk.timestamp = DateTime.Now.ToString();
            //ApplicationUser currentUser = new ApplicationUser(User.Identity.na);
            talk.User = User.Identity.Name;
            //talk.User = currentUser;
            if (ModelState.IsValid)
            {
                db.Talks.Add(talk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talk);
        }

        // GET: Talks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Talk talk = db.Talks.Find(id);
            if (talk.User != User.Identity.Name)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // POST: Talks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TalkID,TalkContent,timestamp")] Talk talk)
        {
            talk.timestamp = ("Edited: " + DateTime.Now);
            talk.User = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(talk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talk);
        }

        // GET: Talks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talk talk = db.Talks.Find(id);
            if (talk == null)
            {
                return HttpNotFound();
            }
            return View(talk);
        }

        // POST: Talks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talk talk = db.Talks.Find(id);
            db.Talks.Remove(talk);
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
