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

        public ActionResult List()
        {

            var projects = db.PROPERTies.ToList();
            ViewData["project"] = projects;
            ViewData["property_type"] = db.PROPERTY_TYPE.ToList();
            ViewData["district"] = db.DISTRICTs.ToList();

            return View();
        }

        public ActionResult Search(int ptypeID, int districtID)
        {
            var projects = db.PROPERTies.AsEnumerable();
            if(ptypeID != 0)
            {
                projects = projects.Where(x => x.PropertyType_ID == ptypeID);
            }
            if (districtID != 0)
            {
                projects = projects.Where(x => x.District_ID == districtID);
            }

            ViewData["project"] = projects.ToList();
            ViewData["property_type"] = db.PROPERTY_TYPE.ToList();
            ViewData["district"] = db.DISTRICTs.ToList();

            return View();
        }
    }
}