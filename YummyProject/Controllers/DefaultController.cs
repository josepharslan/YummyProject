using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;
using System.Data.Entity;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultProduct()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultChef()
        {
            var values = context.Chefs.Include(x => x.ChefSocials).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultGallery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultBook()
        {
            var values = context.Bookings.ToList();
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateBook(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
        public PartialViewResult DefaultContact()
        {
            var values = context.ContactInfos.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultEvents()
        {
            var values = context.Events.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultStats()
        {
            var values = context.Products.Count();
            var values2 = context.Categories.Count();
            var values3 = context.Events.Count();
            var values4 = context.Chefs.Count();
            ViewBag.Count = values;
            ViewBag.Category = values2;
            ViewBag.Event = values3;
            ViewBag.Chef = values4;
            return PartialView();
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            TempData["Message"] = "Mesajınız başarıyla gönderildi!";
            return RedirectToAction("Index");
        }
        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
    }
}