using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Hakkimizdas.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniAbout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniAbout(Hakkimizda p)
        {
            c.Hakkimizdas.Add(p);
            c.SaveChanges();
            return RedirectToAction("AboutListesi");
        }


        public ActionResult AboutListesi()
        {
            var hakkimda = c.Hakkimizdas.ToList();

            return View(hakkimda);
        }
        public ActionResult AboutSil(int id)
        {
            var b = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(b);
            c.SaveChanges();
            return RedirectToAction("AboutListesi");
        }


        public ActionResult AboutGetir(int id)
        {
            var yr = c.Hakkimizdas.Find(id);

            return View("AboutGetir", yr);
        }

        public ActionResult AboutGuncelle(Hakkimizda y)
        {
            var yrm = c.Hakkimizdas.Find(y.ID);
            yrm.Fotourl = y.Fotourl;
                yrm.Aciklama = y.Aciklama;

            c.SaveChanges();
            return RedirectToAction("AboutListesi");




        }
    }
}
