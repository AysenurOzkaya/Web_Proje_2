using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Proje_2.Models;

namespace Web_Proje_2.Controllers
{
    public class BitkisController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: Bitkis
        public ActionResult Index()
        {
            var bitkis = db.Bitkis.Include(b => b.BitkiCin).Include(b => b.BitkiUretim);
            return View(bitkis.ToList());
        }

        // GET: Bitkis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitki bitki = db.Bitkis.Find(id);
            if (bitki == null)
            {
                return HttpNotFound();
            }
            return View(bitki);
        }

        // GET: Bitkis/Create
        public ActionResult Create()
        {
            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd");
            ViewBag.UretimNo = new SelectList(db.BitkiUretims, "UretimNo", "BitkiCinsAd");
            return View();
        }

        // POST: Bitkis/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeriNo,Renk,UretimNo,BitkiCinsAd")] Bitki bitki)
        {
            if (ModelState.IsValid)
            {
                db.Bitkis.Add(bitki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd", bitki.BitkiCinsAd);
            ViewBag.UretimNo = new SelectList(db.BitkiUretims, "UretimNo", "BitkiCinsAd", bitki.UretimNo);
            return View(bitki);
        }

        // GET: Bitkis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitki bitki = db.Bitkis.Find(id);
            if (bitki == null)
            {
                return HttpNotFound();
            }
            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd", bitki.BitkiCinsAd);
            ViewBag.UretimNo = new SelectList(db.BitkiUretims, "UretimNo", "BitkiCinsAd", bitki.UretimNo);
            return View(bitki);
        }

        // POST: Bitkis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeriNo,Renk,UretimNo,BitkiCinsAd")] Bitki bitki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd", bitki.BitkiCinsAd);
            ViewBag.UretimNo = new SelectList(db.BitkiUretims, "UretimNo", "BitkiCinsAd", bitki.UretimNo);
            return View(bitki);
        }

        // GET: Bitkis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitki bitki = db.Bitkis.Find(id);
            if (bitki == null)
            {
                return HttpNotFound();
            }
            return View(bitki);
        }

        // POST: Bitkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bitki bitki = db.Bitkis.Find(id);
            db.Bitkis.Remove(bitki);
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
