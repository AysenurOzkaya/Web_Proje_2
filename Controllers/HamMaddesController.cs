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
    public class HamMaddesController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: HamMaddes
        public ActionResult Index()
        {
            var hamMaddes = db.HamMaddes.Include(h => h.MiktarCin);
            return View(hamMaddes.ToList());
        }

        // GET: HamMaddes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamMadde hamMadde = db.HamMaddes.Find(id);
            if (hamMadde == null)
            {
                return HttpNotFound();
            }
            return View(hamMadde);
        }

        // GET: HamMaddes/Create
        public ActionResult Create()
        {
            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins");
            return View();
        }

        // POST: HamMaddes/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HamMaddeAd,MevcutMiktar,MiktarCins,DepoID")] HamMadde hamMadde)
        {
            if (ModelState.IsValid)
            {
                db.HamMaddes.Add(hamMadde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins", hamMadde.MiktarCins);
            return View(hamMadde);
        }

        // GET: HamMaddes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamMadde hamMadde = db.HamMaddes.Find(id);
            if (hamMadde == null)
            {
                return HttpNotFound();
            }
            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins", hamMadde.MiktarCins);
            return View(hamMadde);
        }

        // POST: HamMaddes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HamMaddeAd,MevcutMiktar,MiktarCins,DepoID")] HamMadde hamMadde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hamMadde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MiktarCins = new SelectList(db.MiktarCins, "MiktarCins", "MiktarCins", hamMadde.MiktarCins);
            return View(hamMadde);
        }

        // GET: HamMaddes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HamMadde hamMadde = db.HamMaddes.Find(id);
            if (hamMadde == null)
            {
                return HttpNotFound();
            }
            return View(hamMadde);
        }

        // POST: HamMaddes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HamMadde hamMadde = db.HamMaddes.Find(id);
            db.HamMaddes.Remove(hamMadde);
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
