using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class DashboardController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            ViewBag.burgerCount = context.Products.Count(x => x.Category.CategoryName == "Burger");
            ViewBag.approvedBooks = context.Bookings.Count(x => x.IsApproved);
            ViewBag.nearestBookingDate = context.Bookings.OrderByDescending(x => x.BookingDate).Select(x => x.BookingDate).FirstOrDefault();
            ViewBag.cheapestPrice = context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
            var values = context.Products.ToList();
            return View(values);
        }
    }
}