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
    public class ZadaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zadanies
        public ActionResult Index()
        {
            return View(db.zadanie.ToList());
        }
        public ActionResult ZadanieGracza(int id)
        {
            return View(db.gracz.Find(id).zadania);
        }
        public ActionResult Search(string search)
        {
            return View(db.zadanie.Where(e => e.opis.ToLower().Contains(search.ToLower())).ToList());
        }
        // GET: Zadanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = db.zadanie.Find(id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            return View(zadanie);
        }

        // GET: Zadanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zadanies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,opis,nagroda,NPC")] Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                db.zadanie.Add(zadanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zadanie);
        }

        // GET: Zadanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = db.zadanie.Find(id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            return View(zadanie);
        }

        // POST: Zadanies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,opis,nagroda,NPC")] Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zadanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zadanie);
        }

        // GET: Zadanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadanie zadanie = db.zadanie.Find(id);
            if (zadanie == null)
            {
                return HttpNotFound();
            }
            return View(zadanie);
        }

        // POST: Zadanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zadanie zadanie = db.zadanie.Find(id);
            db.zadanie.Remove(zadanie);
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
