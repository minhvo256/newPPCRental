using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        // GET: /Account/Register
        team21Entities db = new team21Entities();
        [HttpGet]
        public ActionResult Register()
        {
            USER userModel = new USER();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Register(USER userModel)
        {
            using (team21Entities db = new team21Entities())
            {
                if (db.USERs.Any(x => x.Email == userModel.Email))
                {
                    ViewBag.DuplicateMessage = "Email already exist";
                    return View("Register", userModel);
                }
                userModel.Password = hashPwd(userModel.Password);
                Console.WriteLine(userModel.Password);
                db.USERs.Add(userModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successful Register";
            return View("Register", new USER());
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
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(USER model)
        {
            var userDetails = db.USERs.FirstOrDefault(x => x.Email == model.Email);
            //Console.WriteLine(userDetails);
            if (userDetails.Password == hashPwd(model.Password))
            {
                Session["EmailID"] = userDetails.ID;
                Session["Email"] = userDetails.Email;
                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }
        }
    }
}