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
    public class BitkiTursController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: BitkiTurs
        public ActionResult Index()
        {
            return View(db.BitkiTurs.ToList());
        }

        // GET: BitkiTurs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiTur bitkiTur = db.BitkiTurs.Find(id);
            if (bitkiTur == null)
            {
                return HttpNotFound();
            }
            return View(bitkiTur);
        }

        // GET: BitkiTurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BitkiTurs/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BitkiTurAd,Resim")] BitkiTur bitkiTur)
        {
            if (ModelState.IsValid)
            {
                db.BitkiTurs.Add(bitkiTur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bitkiTur);
        }

        // GET: BitkiTurs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiTur bitkiTur = db.BitkiTurs.Find(id);
            if (bitkiTur == null)
            {
                return HttpNotFound();
            }
            return View(bitkiTur);
        }

        // POST: BitkiTurs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BitkiTurAd,Resim")] BitkiTur bitkiTur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitkiTur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bitkiTur);
        }

        // GET: BitkiTurs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiTur bitkiTur = db.BitkiTurs.Find(id);
            if (bitkiTur == null)
            {
                return HttpNotFound();
            }
            return View(bitkiTur);
        }

        // POST: BitkiTurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BitkiTur bitkiTur = db.BitkiTurs.Find(id);
            db.BitkiTurs.Remove(bitkiTur);
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
