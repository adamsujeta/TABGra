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
    public class PotworsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Potwors
        public ActionResult Index()
        {

            return View(db.potwor.ToList());
        }
        public ActionResult Search(string search)
        {
            return View(db.potwor.Where(e => e.nazwa.ToLower().Contains(search.ToLower())).ToList());
        }
        public ActionResult AddEkwipunek(int id)
        {
            List<SelectListItem> ekwipunekitems = new List<SelectListItem>();

            var ekwipunek = db.ekwipunek.ToList();
            foreach (var ll in ekwipunek)
            {
                ekwipunekitems.Add(new SelectListItem
                {
                    Text = ll.opis,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.ekwipunek = ekwipunekitems;

            return View(db.potwor.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEkwipunek([Bind(Include = "id,nazwa")] Potwor potwor)
        {
            int ekwipunekid = Int32.Parse(Request.Form["ekwipunekSelected"].ToString());
            Potwor p = db.potwor.Find(potwor.id);
            p.ekwipunek.Add(db.ekwipunek.Find(ekwipunekid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(potwor);
        }
        public ActionResult DeleteEkwipunek(int id)
        {
            List<SelectListItem> ekwipunekitems = new List<SelectListItem>();

            var ekwipunek = db.potwor.Find(id).ekwipunek;

            foreach (var ll in ekwipunek)
            {
                ekwipunekitems.Add(new SelectListItem
                {
                    Text = ll.opis,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.ekwipunek = ekwipunekitems;

            return View(db.potwor.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEkwipunek([Bind(Include = "id,nazwa")] Potwor potwor)
        {
            int ekwipunekid = Int32.Parse(Request.Form["ekwipunekSelected"].ToString());
            Potwor p = db.potwor.Find(potwor.id);
            p.ekwipunek.Remove(db.ekwipunek.Find(ekwipunekid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(potwor);
        }
        // GET: Potwors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potwor potwor = db.potwor.Find(id);
            if (potwor == null)
            {
                return HttpNotFound();
            }
            return View(potwor);
        }

        // GET: Potwors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Potwors/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa,doswiadczenie,przedmioty")] Potwor potwor)
        {
            if (ModelState.IsValid)
            {
                db.potwor.Add(potwor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(potwor);
        }

        // GET: Potwors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potwor potwor = db.potwor.Find(id);
            if (potwor == null)
            {
                return HttpNotFound();
            }
            return View(potwor);
        }

        // POST: Potwors/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwa,doswiadczenie,przedmioty")] Potwor potwor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potwor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(potwor);
        }

        // GET: Potwors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potwor potwor = db.potwor.Find(id);
            if (potwor == null)
            {
                return HttpNotFound();
            }
            return View(potwor);
        }

        // POST: Potwors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Potwor potwor = db.potwor.Find(id);
            db.potwor.Remove(potwor);
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
