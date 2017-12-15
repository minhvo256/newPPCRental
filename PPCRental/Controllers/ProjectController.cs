using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class ProjectController : Controller
    {
        team21Entities db = new team21Entities();
        // GET: Detail
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var p = db.PROPERTies.FirstOrDefault( x => x.ID == id);

            ViewData["project"] = p;
            ViewData["district_name"] = db.DISTRICTs.FirstOrDefault(x => x.ID == p.District_ID);
            ViewData["ward_name"] = db.WARDs.FirstOrDefault(x => x.ID == p.Ward_ID);
            ViewData["street_name"] = db.STREETs.FirstOrDefault(x => x.ID == p.Street_ID);

            return View();
  
        }
    }
}