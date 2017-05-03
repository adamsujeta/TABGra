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
    public class GildiasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gildias
        public ActionResult Index()
        {
            return View(db.gildia.ToList());
        }
        public ActionResult Search(string search)
        {
            return View(db.gildia.Where(e => e.nazwa.ToLower().Contains(search.ToLower())).ToList());
        }
        // GET: Gildias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gildia gildia = db.gildia.Find(id);
            if (gildia == null)
            {
                return HttpNotFound();
            }
            return View(gildia);
        }

        // GET: Gildias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gildias/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa,poziom")] Gildia gildia)
        {
            if (ModelState.IsValid)
            {
                db.gildia.Add(gildia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gildia);
        }

        // GET: Gildias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gildia gildia = db.gildia.Find(id);
            if (gildia == null)
            {
                return HttpNotFound();
            }
            return View(gildia);
        }

        // POST: Gildias/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwa,poziom")] Gildia gildia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gildia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gildia);
        }

        // GET: Gildias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gildia gildia = db.gildia.Find(id);
            if (gildia == null)
            {
                return HttpNotFound();
            }
            return View(gildia);
        }

        // POST: Gildias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gildia gildia = db.gildia.Find(id);
            db.gildia.Remove(gildia);
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
        public ActionResult UmiejetnosciGildia(int id)
        {
            return View(db.umiejetnosci.Find(id).gildie);
        }

        #region Umiejetnosci

        public ActionResult AddUmiejetnosci(int id)
        {
            List<SelectListItem> umiejetnosciitems = new List<SelectListItem>();

            var umie = db.umiejetnosci.ToList();
            foreach (var ll in umie)
            {
                umiejetnosciitems.Add(new SelectListItem
                {
                    Text = ll.specyfikacja,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.umiejetnosci = umiejetnosciitems;

            return View(db.gildia.Find(id));
        }
        public ActionResult DeleteUmiejetnosci(int id)
        {
            List<SelectListItem> umiejetnosciitems = new List<SelectListItem>();

            var umie = db.gildia.Find(id).umiejetnosci;

            foreach (var ll in umie)
            {
                umiejetnosciitems.Add(new SelectListItem
                {
                    Text = ll.specyfikacja,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.umiejetnosci = umiejetnosciitems;

            return View(db.gildia.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUmiejetnosci([Bind(Include = "id,nazwa")] Gildia gildia)
        {
            int umieid = Int32.Parse(Request.Form["umiejetnosciSelected"].ToString());
            Gildia p = db.gildia.Find(gildia.id);
            p.umiejetnosci.Remove(db.umiejetnosci.Find(umieid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gildia);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUmiejetnosci([Bind(Include = "id,nazwa")] Gildia gildia)
        {
            int umieid = Int32.Parse(Request.Form["umiejetnosciSelected"].ToString());
            Gildia p = db.gildia.Find(gildia.id);
            p.umiejetnosci.Add(db.umiejetnosci.Find(umieid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gildia);
        }
        #endregion

    }
}
