using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Migrations.Model;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class FeatureController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Features.ToList();
            return View(values);
        }
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View(feature);
            }
            else if (feature.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images";
                var fileName = Path.Combine(saveLocation, feature.ImageFile.FileName);
                feature.ImageFile.SaveAs(fileName);
                feature.ImageUrl = "/images/" + feature.ImageFile.FileName;
            }
            context.Features.Add(feature);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DeleteFeature(int id)
        {
            var values = context.Features.Find(id);
            context.Features.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}