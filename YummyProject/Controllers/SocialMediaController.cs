using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class SocialMediaController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SocialMedia socialMedia)
        {
            context.SocialMedias.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(SocialMedia socialMedia)
        {
            var value = context.SocialMedias.Find(socialMedia.SocialMediaId);
            value.Url = socialMedia.Url;
            value.Title = socialMedia.Title;
            value.Icon = socialMedia.Icon;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}