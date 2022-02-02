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
            HttpCookie mycookie = new HttpCookie("user-access-token");
            mycookie.Value = dbuser.AccessToken;
            mycookie.Expires = DateTime.UtcNow.AddDays(5).AddHours(5);
            Response.Cookies.Remove("user-access-token");
            Response.Cookies.Add(mycookie);
            return Redirect("/Home/Index");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            if (Request.Cookies["user-access-token"] != null)
            {
                Response.Cookies["user-access-token"].Expires = DateTime.UtcNow.AddHours(5).AddDays(-1);
            }
            return Redirect("/Home/Index");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            Status model = db.Statuses.Find(1);
            var List= db.Products.Where(x => x.StatusId == model.Id).ToList();
            foreach (var item in List)
            {
                db.Products.Remove(item);
            }
            db.SaveChanges();
            db.Statuses.Remove(model);
            db.SaveChanges();


            user.RoleId = 2;
            user.AccessToken =DateTime.UtcNow.Ticks.ToString();
            db.Users.Add(user);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

    }
}