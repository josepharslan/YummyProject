using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class EventController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var value = context.Events.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(Event events)
        {
            if (events.ImageFile != null)
            {
                var file = Path.GetFileName(events.ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("/images"), file);
                events.ImageFile.SaveAs(path);
                events.ImageUrl = "/images/" + file;
            }
            context.Events.Add(events);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEvent(int id)
        {
            var value = context.Events.Find(id);
            context.Events.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEvent(int id)
        {
            var value = context.Events.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEvent(Event events)
        {
            var value = context.Events.Find(events.EventId);
            if (events.ImageFile != null)
            {
                var file = Path.GetFileName(events.ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("/images"), file);
                events.ImageFile.SaveAs(path);
                value.ImageUrl = "/images/" + file;
            }
            value.Title = events.Title;
            value.Description = events.Description;
            value.Price = events.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}