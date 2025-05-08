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
    public class AboutController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var value = context.Abouts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            if (about.ImageFile != null && about.ImageFile.ContentLength > 0)
            {
                var fileName1 = Path.GetFileName(about.ImageFile.FileName);
                var savePath1 = Path.Combine(Server.MapPath("/images"), fileName1);
                about.ImageFile.SaveAs(savePath1);
                about.ImageUrl = "/images/" + fileName1;
            }

            if (about.ImageFile2 != null && about.ImageFile2.ContentLength > 0)
            {
                var fileName2 = Path.GetFileName(about.ImageFile2.FileName);
                var savePath2 = Path.Combine(Server.MapPath("/images"), fileName2);
                about.ImageFile2.SaveAs(savePath2);
                about.ImageUrl2 = "/images/" + fileName2;
            }

            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutId);

            value.Item1 = about.Item1;
            value.Item2 = about.Item2;
            value.Item3 = about.Item3;
            value.Description = about.Description;
            value.VideoUrl = about.VideoUrl;
            value.PhoneNumber = about.PhoneNumber;

            if (about.ImageFile != null && about.ImageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(about.ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), fileName);
                about.ImageFile.SaveAs(path);
                value.ImageUrl = "/images/" + fileName;
            }

            if (about.ImageFile2 != null && about.ImageFile2.ContentLength > 0)
            {
                var fileName2 = Path.GetFileName(about.ImageFile2.FileName);
                var path2 = Path.Combine(Server.MapPath("~/images"), fileName2);
                about.ImageFile2.SaveAs(path2);
                value.ImageUrl2 = "/images/" + fileName2;
            }

            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}