using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TABGra.Models;

namespace TABGra.Controllers
{
    [Authorize]
    public class SerwersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Serwers
        public ActionResult Index()
        {
            return View(db.serwer.ToList());
        }
        public ActionResult Search(string search)
        {
            return View(db.serwer.Where(e => e.nazwa.ToLower().Contains(search.ToLower())).ToList());
        }
        // GET: Serwers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwer serwer = db.serwer.Find(id);
            if (serwer == null)
            {
                return HttpNotFound();
            }
            return View(serwer);
        }

        // GET: Serwers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serwers/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_admina,pojemnośc,nazwa")] Serwer serwer)
        {
            if (ModelState.IsValid)
            {
                db.serwer.Add(serwer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serwer);
        }

        // GET: Serwers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwer serwer = db.serwer.Find(id);
            if (serwer == null)
            {
                return HttpNotFound();
            }
            return View(serwer);
        }

        // POST: Serwers/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_admina,pojemnośc,nazwa")] Serwer serwer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serwer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serwer);
        }

        // GET: Serwers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwer serwer = db.serwer.Find(id);
            if (serwer == null)
            {
                return HttpNotFound();
            }
            return View(serwer);
        }

        // POST: Serwers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serwer serwer = db.serwer.Find(id);
            db.serwer.Remove(serwer);
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
