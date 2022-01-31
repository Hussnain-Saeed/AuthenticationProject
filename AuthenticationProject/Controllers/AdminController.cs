using AuthenticationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Models.AuthenticationContext db = new Models.AuthenticationContext();
        public ActionResult Index()
        {
            User dbUser = new CommonController().GetUser(Request);
            if (dbUser != null)
            {
                if (dbUser.RoleId == 1)
                {
                    return View();
                }
            }
            return Redirect("/Home/Index");
        }
    }
}