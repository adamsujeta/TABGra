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
    public class EkwipuneksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ekwipuneks
        public ActionResult Index()
        {
            return View(db.ekwipunek.ToList());
        }
        public ActionResult EkwipunekPotwor(int id)
        {
            return View(db.potwor.Find(id).ekwipunek);
        }
        public ActionResult EkwipunekGracz(int id)
        {
            return View(db.gracz.Find(id).ekwipunek);
        }
        public ActionResult Search(string search)
        {
            return View(db.ekwipunek.Where(e => e.opis.ToLower().Contains(search.ToLower())).ToList());
        }
        // GET: Ekwipuneks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekwipunek ekwipunek = db.ekwipunek.Find(id);
            if (ekwipunek == null)
            {
                return HttpNotFound();
            }
            return View(ekwipunek);
        }

        // GET: Ekwipuneks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ekwipuneks/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,opis")] Ekwipunek ekwipunek)
        {
            if (ModelState.IsValid)
            {
                db.ekwipunek.Add(ekwipunek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ekwipunek);
        }

        // GET: Ekwipuneks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekwipunek ekwipunek = db.ekwipunek.Find(id);
            if (ekwipunek == null)
            {
                return HttpNotFound();
            }
            return View(ekwipunek);
        }

        // POST: Ekwipuneks/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,opis")] Ekwipunek ekwipunek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ekwipunek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ekwipunek);
        }

        // GET: Ekwipuneks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ekwipunek ekwipunek = db.ekwipunek.Find(id);
            if (ekwipunek == null)
            {
                return HttpNotFound();
            }
            return View(ekwipunek);
        }

        // POST: Ekwipuneks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ekwipunek ekwipunek = db.ekwipunek.Find(id);
            db.ekwipunek.Remove(ekwipunek);
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
