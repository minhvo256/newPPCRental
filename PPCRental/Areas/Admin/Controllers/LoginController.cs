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
        // GET: Admin/Login
        team21Entities db = new team21Entities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(USER user)
        {
            if (ModelState.IsValid)
            {
                var userDetails = db.USERs.FirstOrDefault(x => x.Email == user.Email);
                if (userDetails.Password == hashPwd(user.Password))
                {
                    int userID = userDetails.ID;
                    string role = userDetails.Role;
                    Session["userID"] = userID;
                    Session["userRole"] = role;
                    Console.WriteLine(role);
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

        private string hashPwd(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pwd));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}