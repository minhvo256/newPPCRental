using PPCRental.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using PPCRental.Areas.Admin.CodeS;
using PPCRental.Common;
using System.Security.Cryptography;
using System.Text;

namespace PPCRental.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var acc = new UserDB();
                var result = acc.Login(model.username, model.password);
                if (result)
                {
                    var user = acc.GetByID(model.username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Email;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstraints.USER_SESSION, userSession);
                    return RedirectToAction("Index", "/HomeAdmin/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Account does not exist");
                }
            }
            else
            {
                ModelState.AddModelError("", "Account does not exist");
            }
            return View("Index");
        }
    }
}