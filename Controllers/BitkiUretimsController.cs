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
    public class BitkiUretimsController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: BitkiUretims
        public ActionResult Index()
        {
            var bitkiUretims = db.BitkiUretims.Include(b => b.BitkiCin).Include(b => b.Calisan);
            return View(bitkiUretims.ToList());
        }

        // GET: BitkiUretims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiUretim bitkiUretim = db.BitkiUretims.Find(id);
            if (bitkiUretim == null)
            {
                return HttpNotFound();
            }
            return View(bitkiUretim);
        }

        // GET: BitkiUretims/Create
        public ActionResult Create()
        {
            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd");
            ViewBag.Kayıt_Eden_Calisan = new SelectList(db.Calisans, "CalisanID", "Sifre");
            return View();
        }

        // POST: BitkiUretims/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UretimNo,SeraNo,UretimAded,BitkiCinsAd,Tarih,Renk,Kayıt_Eden_Calisan")] BitkiUretim bitkiUretim)
        {
            if (ModelState.IsValid)
            {
                db.BitkiUretims.Add(bitkiUretim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd", bitkiUretim.BitkiCinsAd);
            ViewBag.Kayıt_Eden_Calisan = new SelectList(db.Calisans, "CalisanID", "Sifre", bitkiUretim.Kayıt_Eden_Calisan);
            return View(bitkiUretim);
        }

        // GET: BitkiUretims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiUretim bitkiUretim = db.BitkiUretims.Find(id);
            if (bitkiUretim == null)
            {
                return HttpNotFound();
            }
            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd", bitkiUretim.BitkiCinsAd);
            ViewBag.Kayıt_Eden_Calisan = new SelectList(db.Calisans, "CalisanID", "Sifre", bitkiUretim.Kayıt_Eden_Calisan);
            return View(bitkiUretim);
        }

        // POST: BitkiUretims/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UretimNo,SeraNo,UretimAded,BitkiCinsAd,Tarih,Renk,Kayıt_Eden_Calisan")] BitkiUretim bitkiUretim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitkiUretim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BitkiCinsAd = new SelectList(db.BitkiCins, "BitkiCinsAd", "LatinceAd", bitkiUretim.BitkiCinsAd);
            ViewBag.Kayıt_Eden_Calisan = new SelectList(db.Calisans, "CalisanID", "Sifre", bitkiUretim.Kayıt_Eden_Calisan);
            return View(bitkiUretim);
        }

        // GET: BitkiUretims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiUretim bitkiUretim = db.BitkiUretims.Find(id);
            if (bitkiUretim == null)
            {
                return HttpNotFound();
            }
            return View(bitkiUretim);
        }

        // POST: BitkiUretims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BitkiUretim bitkiUretim = db.BitkiUretims.Find(id);
            db.BitkiUretims.Remove(bitkiUretim);
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
