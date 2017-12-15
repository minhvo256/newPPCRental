using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class HomePageController : Controller
    {

        team21Entities db = new team21Entities();
        // GET: HomePage
        public ActionResult Index()
        {
            var project = db.PROPERTies.OrderByDescending(x => x.ID).Take(6).ToList();
            ViewData["project"] = project;
            return View();
        }

        [HttpPost]
        public ActionResult Search (string text)
        {
            var product = db.PROPERTies.Where(x => x.PropertyName.ToLower().Contains(text.ToLower())).ToList();

            if (product.Count()>0)
            {
                ViewBag.Message = "  ";
               
            }
            else
            {
                ViewBag.Message = "No Property found";
                    
            }
            ViewData["project"] = product;
            return View();
        }
        public ActionResult AboutUS()
        {
            ViewBag.Message = "Your website description page";
            return View();
        }

        public ActionResult Contact()
        {
            
            return View();
        }
        public ActionResult Project()
        {
            var project = ViewData["project"] as List<PPCRental.Models.PROPERTY>;
            return View();
        }



    }
}