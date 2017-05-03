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
    public class UmiejetnoscisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Umiejetnoscis
        public ActionResult Index()
        {
            return View(db.umiejetnosci.ToList());
        }
        public ActionResult UmiejetnosciGracza(int id)
        {
            return View(db.gracz.Find(id).umiejetnosci);
        }
        public ActionResult UmiejetnosciGildii(int id)
        {
            return View(db.gildia.Find(id).umiejetnosci);
        }
        public ActionResult Search(string search)
        {
            return View(db.umiejetnosci.Where(e => e.specyfikacja.ToLower().Contains(search.ToLower())).ToList());
        }
        // GET: Umiejetnoscis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umiejetnosci umiejetnosci = db.umiejetnosci.Find(id);
            if (umiejetnosci == null)
            {
                return HttpNotFound();
            }
            return View(umiejetnosci);
        }

        // GET: Umiejetnoscis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Umiejetnoscis/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,specyfikacja,poziom")] Umiejetnosci umiejetnosci)
        {
            if (ModelState.IsValid)
            {
                db.umiejetnosci.Add(umiejetnosci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(umiejetnosci);
        }

        // GET: Umiejetnoscis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umiejetnosci umiejetnosci = db.umiejetnosci.Find(id);
            if (umiejetnosci == null)
            {
                return HttpNotFound();
            }
            return View(umiejetnosci);
        }

        // POST: Umiejetnoscis/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,specyfikacja,poziom")] Umiejetnosci umiejetnosci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(umiejetnosci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(umiejetnosci);
        }

        // GET: Umiejetnoscis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umiejetnosci umiejetnosci = db.umiejetnosci.Find(id);
            if (umiejetnosci == null)
            {
                return HttpNotFound();
            }
            return View(umiejetnosci);
        }

        // POST: Umiejetnoscis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Umiejetnosci umiejetnosci = db.umiejetnosci.Find(id);
            db.umiejetnosci.Remove(umiejetnosci);
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
