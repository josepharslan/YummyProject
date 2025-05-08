using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ServiceController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var value = context.Services.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult Update(Service service)
        {
            var value = context.Services.Find(service.ServiceId);
            value.Title = service.Title;
            value.Description = service.Description;
            value.Icon = service.Icon;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
