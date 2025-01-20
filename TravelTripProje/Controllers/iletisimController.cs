using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;


namespace TravelTripProje.Controllers
{
    public class iletisimController : Controller
    {
        Context c = new Context();

        // GET: İletişim
        public ActionResult Index()
        {
            return View();
        }

        // POST: İletişim
        [HttpPost]
        public ActionResult Index(iletişim iletisim)
        {
            if (ModelState.IsValid)
            {
                c.iletişims.Add(iletisim);
                c.SaveChanges();
                ViewBag.Message = "Mesajınız başarıyla gönderildi!";
                return View();
            }
            return View(iletisim);
        }
    }
}