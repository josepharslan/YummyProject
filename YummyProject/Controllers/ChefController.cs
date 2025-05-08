using Microsoft.Ajax.Utilities;
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
    public class ChefController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var value = context.Chefs.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChef(Chef chef)
        {
            if (chef.ImageFile != null)
            {
                var filename = Path.GetFileName(chef.ImageFile.FileName);
                var savepath = Path.Combine(Server.MapPath("/images"), filename);
                chef.ImageFile.SaveAs(savepath);
                chef.ImageUrl = "/images/" + filename;
            }
            context.Chefs.Add(chef);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var chef = context.Chefs.Find(id);
            return View(chef);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef chef)
        {
            var value = context.Chefs.Find(chef.ChefId);

            value.Name = chef.Name;
            value.Title = chef.Title;
            value.Description = chef.Description;

            if (chef.ImageFile != null)
            {
                var filename = Path.GetFileName(chef.ImageFile.FileName);
                var savepath = Path.Combine(Server.MapPath("/images"), filename);
                chef.ImageFile.SaveAs(savepath);
                value.ImageUrl = "/images/" + filename;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteChef(int id)
        {
            var chef = context.Chefs.Find(id);
            context.Chefs.Remove(chef);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}