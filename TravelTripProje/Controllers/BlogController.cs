using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c= new Context();
        BlogYorum by = new BlogYorum();


        public ActionResult Index()
        {
            // İlk olarak blogları alıyoruz
            by.Deger1 = c.Blogs.ToList();

            // Sonra en son 2 blogu alıyoruz (Take(2) ile)
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();

            // Yorumları alıyoruz (Take(2) ile son 2 yorumu)
            by.Deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(2).ToList();

            // Son olarak view'ı geri döndürüyoruz
            return View(by);
        }


        public ActionResult BlogDetay(int id)
        {

            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            // Sonra en son 2 blogu alıyoruz (Take(2) ile)
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();

            // Yorumları alıyoruz (Take(2) ile son 2 yorumu)
            by.Deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(2).ToList();

            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

      
         [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {

            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}