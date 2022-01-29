using AuthenticationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace AuthenticationProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Models.AuthenticationContext db = new Models.AuthenticationContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            //goes to =>
            User dbuser=db.Users.Where(m => m.Email == user.Email && m.Password == user.Password).FirstOrDefault();
            if (dbuser == null)
            {
                ViewBag.Error = "Your email or password is incorrect";
                return View();
            }
            return Redirect("/Product/Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            user.RoleId = 2;
            user.AccessToken = RandomString(10)+ DateTime.UtcNow.Ticks.ToString();
            db.Users.Add(user);
            db.SaveChanges();
            return Redirect("/Product/Index");
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}