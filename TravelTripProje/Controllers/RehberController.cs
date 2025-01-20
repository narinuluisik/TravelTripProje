using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class RehberController : Controller
    {
        // GET: Rehber
       
        Context c = new Context();

        // Oteller Listesi
        public ActionResult Hotels()
        {
            var hotels = c.Hotels.ToList();
            return View(hotels);
        }

        // Restoranlar Listesi
        public ActionResult Restaurants()
        {
            var restaurants = c.Restaurants.ToList();
            return View(restaurants);
        }

        // Müzeler Listesi
        public ActionResult Museums()
        {
            var museums = c.Museums.ToList();
            return View(museums);
        }
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
   