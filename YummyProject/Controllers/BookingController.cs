using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class BookingController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var value = context.Bookings.OrderByDescending(x => x.BookingDate).ToList();
            return View(value);
        }
        public ActionResult Approved()
        {
            var value = context.Bookings.OrderByDescending(x => x.BookingDate).Where(x => x.IsApproved == true).ToList();
            return View(value);
        }
        public ActionResult NotApproved()
        {
            var value = context.Bookings.OrderByDescending(x => x.BookingDate).Where(x => x.IsApproved == false).ToList();
            return View(value);
        }
        public ActionResult IsApproved(int id)
        {
            var value = context.Bookings.Find(id);

            value.IsApproved = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult IsntApproved(int id)
        {
            var value = context.Bookings.Find(id);
            value.IsApproved = false;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}