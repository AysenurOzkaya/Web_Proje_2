using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_Proje_2.Models;

namespace Web_Proje_2.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        Web_ProgramlamaEntities db = new Web_ProgramlamaEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Calisan calisan)
        {
            var musteriInDb = db.Musteris.FirstOrDefault(x => x.MusteriID == calisan.CalisanID && x.Email == calisan.Sifre);
            var calisanInDb = db.Calisans.FirstOrDefault(x => x.CalisanID == calisan.CalisanID && x.Sifre == calisan.Sifre);
            if (calisanInDb != null)
            {
                FormsAuthentication.SetAuthCookie(calisan.CalisanID.ToString(), false);
                return RedirectToAction("Index", "Home2");
            }
            if (musteriInDb != null)
            {
                FormsAuthentication.SetAuthCookie(calisan.CalisanID.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kayıt Dışı Kullanıcı veya Hatalı şifre";
                return View();
            }


        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
