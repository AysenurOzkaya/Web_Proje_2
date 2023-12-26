using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web_Proje_2.Controllers
{
    public class Home2Controller : Controller
    {
        // GET: Home2
        [Authorize]
        public ActionResult Index()
        {
            string[] ekle = { "BahceMalzemeleris", "BitkiCins", "BitkiUretims", "Calisans", "HamMaddeSatinAlmas", "Musteris","HamMaddes", "Tedarikcis" }; 
            
            return View(ekle);
        }

        [HttpPost]
        public ActionResult Index(string id)
        {
            string Controller = id+"Index";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }
    }
}