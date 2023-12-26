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
    public class TedarikcisController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();

        // GET: Tedarikcis
        public ActionResult Index()
        {
            return View(db.Tedarikcis.ToList());
        }

        // GET: Tedarikcis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tedarikci tedarikci = db.Tedarikcis.Find(id);
            if (tedarikci == null)
            {
                return HttpNotFound();
            }
            return View(tedarikci);
        }

        // GET: Tedarikcis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tedarikcis/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TedarikciID,FirmaAd,Adres,Telefon,Email,IBAN")] Tedarikci tedarikci)
        {
            if (ModelState.IsValid)
            {
                db.Tedarikcis.Add(tedarikci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tedarikci);
        }

        // GET: Tedarikcis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tedarikci tedarikci = db.Tedarikcis.Find(id);
            if (tedarikci == null)
            {
                return HttpNotFound();
            }
            return View(tedarikci);
        }

        // POST: Tedarikcis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TedarikciID,FirmaAd,Adres,Telefon,Email,IBAN")] Tedarikci tedarikci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tedarikci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tedarikci);
        }

        // GET: Tedarikcis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tedarikci tedarikci = db.Tedarikcis.Find(id);
            if (tedarikci == null)
            {
                return HttpNotFound();
            }
            return View(tedarikci);
        }

        // POST: Tedarikcis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tedarikci tedarikci = db.Tedarikcis.Find(id);
            db.Tedarikcis.Remove(tedarikci);
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
