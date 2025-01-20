using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
      
            return View("BlogGetir",bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var bl = c.Blogs.Find(b.ID);
                bl.Aciklama=b.Aciklama;
            bl.Baslik = b.Baslik;
            bl.BlogImage = b.BlogImage;
            bl.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult YorumListesi( )
        {
            var yorumlar = c.Yorumlars.ToList();

            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
           
            return View("YorumGetir",yr);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;

          
            c.SaveChanges();
            return RedirectToAction("YorumListesi");



    
        }
        public ActionResult iletişimListesi()
        {
            var yorumlar = c.iletişims.ToList();

            return View(yorumlar);
        }
        public ActionResult iletişimSil(int id)
        {
            var b = c.iletişims.Find(id);
            c.iletişims.Remove(b);
            c.SaveChanges();
            return RedirectToAction("iletişimListesi");
        }


        public ActionResult iletişimGetir(int id)
        {
            var yr = c.iletişims.Find(id);

            return View("iletişimGetir", yr);
        }

        public ActionResult iletişimGuncelle(iletişim y)
        {
            var yrm = c.iletişims.Find(y.ID);
            yrm.AdSoyad = y.AdSoyad;
            yrm.Mail = y.Mail;
            yrm.Konu = y.Konu;
            yrm.Mesaj = y.Mesaj;

            c.SaveChanges();
            return RedirectToAction("iletişimListesi");




        }
    }


}