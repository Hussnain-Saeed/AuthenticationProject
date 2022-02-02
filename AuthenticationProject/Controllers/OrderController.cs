using AuthenticationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationProject.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        Models.AuthenticationContext db = new Models.AuthenticationContext();

        public ActionResult BuyNow(int Id)
        {

            User dbUser = new CommonController().GetUser(Request);
            if (dbUser != null)
            {
                Order order = new Order
                {
                    AddedOn = DateTime.UtcNow.AddHours(5),
                    BuyerId = dbUser.Id,
                    ProductId=Id
                };
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("PurchasedOrders");
            }
            return Redirect("/Account/Login");
        }
        public ActionResult PurchasedOrders()
        {
            User dbUser = new CommonController().GetUser(Request);
            if (dbUser != null)
            {
                List<Order> orders = db.Orders.Where(x => x.BuyerId == dbUser.Id).ToList();
                return View(orders);
            }
            return Redirect("/Account/Login");
        }
    }
}