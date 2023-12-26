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
    public class BahceMalzemelerisController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: BahceMalzemeleris
        public ActionResult Index()
        {
            var bahceMalzemeleris = db.BahceMalzemeleris.Include(b => b.Tedarikci);
            return View(bahceMalzemeleris.ToList());
        }

        // GET: BahceMalzemeleris/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BahceMalzemeleri bahceMalzemeleri = db.BahceMalzemeleris.Find(id);
            if (bahceMalzemeleri == null)
            {
                return HttpNotFound();
            }
            return View(bahceMalzemeleri);
        }

        // GET: BahceMalzemeleris/Create
        public ActionResult Create()
        {
            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd");
            return View();
        }

        // POST: BahceMalzemeleris/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BahceMalzemeAd,MevcutAdet,Fiyat,Resim,TedarikciID")] BahceMalzemeleri bahceMalzemeleri)
        {
            if (ModelState.IsValid)
            {
                db.BahceMalzemeleris.Add(bahceMalzemeleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd", bahceMalzemeleri.TedarikciID);
            return View(bahceMalzemeleri);
        }

        // GET: BahceMalzemeleris/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BahceMalzemeleri bahceMalzemeleri = db.BahceMalzemeleris.Find(id);
            if (bahceMalzemeleri == null)
            {
                return HttpNotFound();
            }
            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd", bahceMalzemeleri.TedarikciID);
            return View(bahceMalzemeleri);
        }

        // POST: BahceMalzemeleris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BahceMalzemeAd,MevcutAdet,Fiyat,Resim,TedarikciID")] BahceMalzemeleri bahceMalzemeleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bahceMalzemeleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd", bahceMalzemeleri.TedarikciID);
            return View(bahceMalzemeleri);
        }

        // GET: BahceMalzemeleris/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BahceMalzemeleri bahceMalzemeleri = db.BahceMalzemeleris.Find(id);
            if (bahceMalzemeleri == null)
            {
                return HttpNotFound();
            }
            return View(bahceMalzemeleri);
        }

        // POST: BahceMalzemeleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BahceMalzemeleri bahceMalzemeleri = db.BahceMalzemeleris.Find(id);
            db.BahceMalzemeleris.Remove(bahceMalzemeleri);
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
