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
    public class GraczsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Graczs
        public ActionResult Index()
        {
            return View(db.gracz.ToList());
        }
        public ActionResult Search(string search)
        {
            return View(db.gracz.Where(e => e.nazwa.ToLower().Contains(search.ToLower())).ToList());
        }
        public ActionResult SerwerGracze(int id)
        {
            return View(db.gracz.Where(g=>g.serwer.id==id).ToList());
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

            return View(db.gracz.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEkwipunek([Bind(Include = "id,nazwa")] Gracz gracz)
        {
            int ekwipunekid = Int32.Parse(Request.Form["ekwipunekSelected"].ToString());
            Gracz p = db.gracz.Find(gracz.id);
            p.ekwipunek.Add(db.ekwipunek.Find(ekwipunekid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gracz);
        }
        public ActionResult DeleteEkwipunek(int id)
        {
            List<SelectListItem> ekwipunekitems = new List<SelectListItem>();

            var ekwipunek = db.gracz.Find(id).ekwipunek;

            foreach (var ll in ekwipunek)
            {
                ekwipunekitems.Add(new SelectListItem
                {
                    Text = ll.opis,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.ekwipunek = ekwipunekitems;

            return View(db.gracz.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEkwipunek([Bind(Include = "id,nazwa")] Gracz gracz)
        {
            int ekwipunekid = Int32.Parse(Request.Form["ekwipunekSelected"].ToString());
            Gracz p = db.gracz.Find(gracz.id);
            p.ekwipunek.Remove(db.ekwipunek.Find(ekwipunekid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gracz);
        }


        // GET: Graczs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gracz gracz = db.gracz.Find(id);
            if (gracz == null)
            {
                return HttpNotFound();
            }
            return View(gracz);
        }

        // GET: Graczs/Create
        public ActionResult Create()
        {
            List<SelectListItem> serweritems = new List<SelectListItem>();

            var serwer = db.serwer.ToList();
            foreach (var ll in serwer)
            {
                serweritems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.serwer = serweritems;

            List<SelectListItem> Gildiaitems = new List<SelectListItem>();
            Gildiaitems.Add(new SelectListItem
            {
                Text = "brak",
                Value = "-1"
            });
            var gildia = db.gildia.ToList();
            foreach (var ll in gildia)
            {
                Gildiaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.gildia = Gildiaitems;
            return View();
        }

        // POST: Graczs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nazwa,doswiadczenie,sila,zycia,poziom")] Gracz gracz)
        {
            int serwerid = Int32.Parse(Request.Form["serwerSelected"].ToString());
            int gildiaid = Int32.Parse(Request.Form["gildiaSelected"].ToString());
            gracz.serwer = db.serwer.Find(serwerid);
            gracz.gildia = db.gildia.Find(gildiaid);
            if (ModelState.IsValid)
            {
                db.gracz.Add(gracz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gracz);
        }

        // GET: Graczs/Edit/5
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> serweritems = new List<SelectListItem>();

            var serwer = db.serwer.ToList();
            foreach (var ll in serwer)
            {
                serweritems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.serwer = serweritems;

            List<SelectListItem> Gildiaitems = new List<SelectListItem>();
            Gildiaitems.Add(new SelectListItem
            {
                Text = "brak",
                Value = "-1"
            });
            var gildia = db.gildia.ToList();
            foreach (var ll in gildia)
            {
                Gildiaitems.Add(new SelectListItem
                {
                    Text = ll.nazwa,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.gildia = Gildiaitems;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gracz gracz = db.gracz.Find(id);
            if (gracz == null)
            {
                return HttpNotFound();
            }
            return View(gracz);
        }

        // POST: Graczs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwa,doswiadczenie,sila,zycia,poziom")] Gracz gracz)
        {
            int serwerid = Int32.Parse(Request.Form["serwerSelected"].ToString());
            int gildiaid = Int32.Parse(Request.Form["gildiaSelected"].ToString());
            Gracz ng = db.gracz.Find(gracz.id);
            ng.nazwa = gracz.nazwa;
            ng.doswiadczenie = gracz.doswiadczenie;
            ng.sila = gracz.sila;
            ng.zycia = gracz.zycia;
            ng.poziom = gracz.poziom;
            ng.serwer = db.serwer.Find(serwerid);
            ng.gildia = db.gildia.Find(gildiaid);

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gracz);
        }

        // GET: Graczs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gracz gracz = db.gracz.Find(id);
            if (gracz == null)
            {
                return HttpNotFound();
            }
            return View(gracz);
        }

        // POST: Graczs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gracz gracz = db.gracz.Find(id);
            db.gracz.Remove(gracz);
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
        #region zadanie

        public ActionResult GraczeZadanie(int id)
        {
            return View(db.umiejetnosci.Find(id).gracze);
        }
        public ActionResult AddZadanie(int id)
        {
            List<SelectListItem> zadanieitem = new List<SelectListItem>();

            var zadanie = db.zadanie.ToList();
            foreach (var ll in zadanie)
            {
                zadanieitem.Add(new SelectListItem
                {
                    Text = ll.opis,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.zadanie = zadanieitem;

            return View(db.gracz.Find(id));
        }
        public ActionResult DeleteZadanie(int id)
        {
            List<SelectListItem> zadanieitems = new List<SelectListItem>();

            var zadanie = db.gracz.Find(id).zadania;

            foreach (var ll in zadanie)
            {
                zadanieitems.Add(new SelectListItem
                {
                    Text = ll.opis,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.zadanie = zadanieitems;

            return View(db.gracz.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteZadanie([Bind(Include = "id,nazwa")] Gracz gracz)
        {
            int zadanieid = Int32.Parse(Request.Form["zadanieSelected"].ToString());
            Gracz p = db.gracz.Find(gracz.id);
            p.zadania.Remove(db.zadanie.Find(zadanieid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gracz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddZadanie([Bind(Include = "id,nazwa")] Gracz gracz)
        {
            int zadanieid = Int32.Parse(Request.Form["zadanieSelected"].ToString());
            Gracz p = db.gracz.Find(gracz.id);
            p.zadania.Add(db.zadanie.Find(zadanieid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gracz);
        }
        #endregion
        public ActionResult GraczeGildii(int id)
        {
            return View(db.gildia.Find(id).gracze);
        }
        #region Umiejetnosci

        public ActionResult GraczeUmiejetnosci(int id)
        {
            return View(db.umiejetnosci.Find(id).gracze);
        }
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

            return View(db.gracz.Find(id));
        }
        public ActionResult DeleteUmiejetnosci(int id)
        {
            List<SelectListItem> umiejetnosciitems = new List<SelectListItem>();

            var umie = db.gracz.Find(id).umiejetnosci;

            foreach (var ll in umie)
            {
                umiejetnosciitems.Add(new SelectListItem
                {
                    Text = ll.specyfikacja,
                    Value = ll.id.ToString()
                });
            }
            ViewBag.umiejetnosci = umiejetnosciitems;

            return View(db.gracz.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUmiejetnosci([Bind(Include = "id,nazwa")] Gracz gracz)
        {
            int umieid = Int32.Parse(Request.Form["umiejetnosciSelected"].ToString());
            Gracz p = db.gracz.Find(gracz.id);
            p.umiejetnosci.Remove(db.umiejetnosci.Find(umieid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gracz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUmiejetnosci([Bind(Include = "id,nazwa")] Gracz gracz)
        {
            int umieid = Int32.Parse(Request.Form["umiejetnosciSelected"].ToString());
            Gracz p = db.gracz.Find(gracz.id);
            p.umiejetnosci.Add(db.umiejetnosci.Find(umieid));
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gracz);
        }
        #endregion

    }
}
