using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Web_Proje_2.Models;

namespace Web_Proje_2.Controllers
{
    public class HomeController : Controller
    {
        private Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bitki()
        {
            return View(db.BitkiTurs.ToList());
        }

        public ActionResult BahceMalzeme()
        {
            return View(db.BahceMalzemeleris.ToList());
        }

        public ActionResult Yon(string id)
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

        [HttpPost, ActionName("Yon")]
        public ActionResult YonConfirmed(string id)
        {
            var bitkiCin = db.BitkiCins.Find(id);
            int a = 0;
            Web_Proje_2.Models.Sipari siparis = new Web_Proje_2.Models.Sipari();
            Web_Proje_2.Models.Musteri m = new Web_Proje_2.Models.Musteri();

            siparis.BitkiCinsAd = id;
            foreach (var item in db.Siparis)
            {
                a++;
            }

            siparis.SiparisID = a + 1;
            siparis.MusteriID = 1;
            int l = siparis.MusteriID;
            m = db.Musteris.Find(l);
            siparis.BitkiCinsAd = id;
            siparis.SiparisTarihi = DateTime.Now;
            siparis.SiparisAdedi = 1;
            siparis.Adres = m.Adres;
            db.Siparis.Add(siparis);
            db.SaveChanges();
            

            return View(bitkiCin);

        }





        public ActionResult YonMalzeme(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bm = db.BahceMalzemeleris.Find(id);
            if (bm == null)
            {
                return HttpNotFound();
            }
            return View(bm);

        }

        [HttpPost, ActionName("YonMalzeme")]
        public ActionResult YonMalzemeConfirmed(string id)
        {
            var bm = db.BahceMalzemeleris.Find(id);
            int a = 0;
            Web_Proje_2.Models.Sipari siparis = new Web_Proje_2.Models.Sipari();
            Web_Proje_2.Models.Musteri m = new Web_Proje_2.Models.Musteri();

            siparis.YanMalzeme = id;
            foreach (var item in db.Siparis)
            {
                a++;
            }

            siparis.SiparisID = a + 1;
            siparis.MusteriID = 1;
            int l = siparis.MusteriID;
            m = db.Musteris.Find(l);
            siparis.SiparisTarihi = DateTime.Now;
            siparis.SiparisAdedi = 1;
            siparis.Adres = m.Adres;
            db.Siparis.Add(siparis);
            db.SaveChanges();


            return View(bm);

        }






        public ActionResult BitkiTurSecim(string id)
        {
            
            var IstenenTur = db.BitkiCins
        .Where(p => p.BitkiTur1.BitkiTurAd.Equals(id, StringComparison.OrdinalIgnoreCase))
        .ToList();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BitkiTur bitkiTur = db.BitkiTurs.Find(id);
            if (bitkiTur == null)
            {
                return HttpNotFound();
            }
       
            
            return View(IstenenTur);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}