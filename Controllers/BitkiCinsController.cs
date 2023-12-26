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
    public class BitkiCinsController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: BitkiCins
       
        public ActionResult Index()
        {
            var bitkiCins = db.BitkiCins.Include(b => b.BitkiTur1);
            return View(bitkiCins.ToList());
        }

        // GET: BitkiCins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bitkiCin = db.BitkiCins.Find(id);
            if (bitkiCin == null)
            {
                return HttpNotFound();
            }
            return View(bitkiCin);
        }


      

        // GET: BitkiCins/Create
        public ActionResult Create()
        {
            ViewBag.BitkiTur = new SelectList(db.BitkiTurs, "BitkiTurAd", "Resim");
            return View();
        }

        // POST: BitkiCins/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BitkiCinsAd,MevcutAded,LatinceAd,BitkiTur,Fiyat,Resim,DepoID")] BitkiCin bitkiCin)
        {
            if (ModelState.IsValid)
            {
                db.BitkiCins.Add(bitkiCin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BitkiTur = new SelectList(db.BitkiTurs, "BitkiTurAd", "Resim", bitkiCin.BitkiTur);
            return View(bitkiCin);
        }

        // GET: BitkiCins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiCin bitkiCin = db.BitkiCins.Find(id);
            if (bitkiCin == null)
            {
                return HttpNotFound();
            }
            ViewBag.BitkiTur = new SelectList(db.BitkiTurs, "BitkiTurAd", "Resim", bitkiCin.BitkiTur);
            return View(bitkiCin);
        }

        // POST: BitkiCins/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BitkiCinsAd,MevcutAded,LatinceAd,BitkiTur,Fiyat,Resim,DepoID")] BitkiCin bitkiCin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitkiCin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BitkiTur = new SelectList(db.BitkiTurs, "BitkiTurAd", "Resim", bitkiCin.BitkiTur);
            return View(bitkiCin);
        }

        // GET: BitkiCins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiCin bitkiCin = db.BitkiCins.Find(id);
            if (bitkiCin == null)
            {
                return HttpNotFound();
            }
            return View(bitkiCin);
        }

        // POST: BitkiCins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BitkiCin bitkiCin = db.BitkiCins.Find(id);
            db.BitkiCins.Remove(bitkiCin);
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
