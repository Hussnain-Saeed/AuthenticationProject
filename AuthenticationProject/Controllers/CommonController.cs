using AuthenticationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationProject.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        Models.AuthenticationContext db = new Models.AuthenticationContext();
        public User GetUser(HttpRequestBase request)
        {
            string AccessToken = "";
            if (request.Cookies.Get("user-access-token") != null)
                AccessToken = request.Cookies.Get("user-access-token").Value;

            return db.Users.Where(x => x.AccessToken == AccessToken).FirstOrDefault();
            
        }
    }
}