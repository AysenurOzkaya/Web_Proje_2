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
    public class HamMadde_SatinAlmaController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: HamMadde_SatinAlma
        public ActionResult Index()
        {
            var hamMadde_SatinAlma = db.HamMadde_SatinAlma.Include(h => h.Calisan).Include(h => h.HamMadde).Include(h => h.MiktarCin).Include(h => h.Tedarikci);
            return View(hamMadde_SatinAlma.ToList());
        }

        // GET: HamMadde_SatinAlma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamMadde_SatinAlma hamMadde_SatinAlma = db.HamMadde_SatinAlma.Find(id);
            if (hamMadde_SatinAlma == null)
            {
                return HttpNotFound();
            }
            return View(hamMadde_SatinAlma);
        }

        // GET: HamMadde_SatinAlma/Create
        public ActionResult Create()
        {
            ViewBag.SatinAlanCalisan = new SelectList(db.Calisans, "CalisanID", "Sifre");
            ViewBag.HamMaddeAd = new SelectList(db.HamMaddes, "HamMaddeAd", "MiktarCins");
            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins");
            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd");
            return View();
        }

        // POST: HamMadde_SatinAlma/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatinAlmaNumarasi,HamMaddeAd,TedarikciID,MiktarCins,Miktar,Tutar,SatinAlanCalisan")] HamMadde_SatinAlma hamMadde_SatinAlma)
        {
            if (ModelState.IsValid)
            {
                db.HamMadde_SatinAlma.Add(hamMadde_SatinAlma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SatinAlanCalisan = new SelectList(db.Calisans, "CalisanID", "Sifre", hamMadde_SatinAlma.SatinAlanCalisan);
            ViewBag.HamMaddeAd = new SelectList(db.HamMaddes, "HamMaddeAd", "MiktarCins", hamMadde_SatinAlma.HamMaddeAd);
            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins", hamMadde_SatinAlma.MiktarCins);
            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd", hamMadde_SatinAlma.TedarikciID);
            return View(hamMadde_SatinAlma);
        }

        // GET: HamMadde_SatinAlma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamMadde_SatinAlma hamMadde_SatinAlma = db.HamMadde_SatinAlma.Find(id);
            if (hamMadde_SatinAlma == null)
            {
                return HttpNotFound();
            }
            ViewBag.SatinAlanCalisan = new SelectList(db.Calisans, "CalisanID", "Sifre", hamMadde_SatinAlma.SatinAlanCalisan);
            ViewBag.HamMaddeAd = new SelectList(db.HamMaddes, "HamMaddeAd", "MiktarCins", hamMadde_SatinAlma.HamMaddeAd);
            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins", hamMadde_SatinAlma.MiktarCins);
            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd", hamMadde_SatinAlma.TedarikciID);
            return View(hamMadde_SatinAlma);
        }

        // POST: HamMadde_SatinAlma/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatinAlmaNumarasi,HamMaddeAd,TedarikciID,MiktarCins,Miktar,Tutar,SatinAlanCalisan")] HamMadde_SatinAlma hamMadde_SatinAlma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hamMadde_SatinAlma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SatinAlanCalisan = new SelectList(db.Calisans, "CalisanID", "Sifre", hamMadde_SatinAlma.SatinAlanCalisan);
            ViewBag.HamMaddeAd = new SelectList(db.HamMaddes, "HamMaddeAd", "MiktarCins", hamMadde_SatinAlma.HamMaddeAd);
            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins", hamMadde_SatinAlma.MiktarCins);
            ViewBag.TedarikciID = new SelectList(db.Tedarikcis, "TedarikciID", "FirmaAd", hamMadde_SatinAlma.TedarikciID);
            return View(hamMadde_SatinAlma);
        }

        // GET: HamMadde_SatinAlma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamMadde_SatinAlma hamMadde_SatinAlma = db.HamMadde_SatinAlma.Find(id);
            if (hamMadde_SatinAlma == null)
            {
                return HttpNotFound();
            }
            return View(hamMadde_SatinAlma);
        }

        // POST: HamMadde_SatinAlma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HamMadde_SatinAlma hamMadde_SatinAlma = db.HamMadde_SatinAlma.Find(id);
            db.HamMadde_SatinAlma.Remove(hamMadde_SatinAlma);
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
