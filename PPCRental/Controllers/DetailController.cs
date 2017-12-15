using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class DetailController : Controller
    {
        team21Entities db = new team21Entities();
        // GET: Detail
        public ActionResult Detail(int id, string name)
        {
            var p = db.PROPERTies.FirstOrDefault(x => x.ID == id || x.PropertyName == name);
            ViewBag.street = db.STREETs.FirstOrDefault(x => x.ID == id);
            ViewBag.district = db.DISTRICTs.FirstOrDefault(x => x.ID == id);
            ViewBag.ward = db.WARDs.FirstOrDefault(x => x.ID == id);
            return View(p);
  
        }
    }
}