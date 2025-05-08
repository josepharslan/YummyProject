using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ChefSocialMediasController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index(int id)
        {
            var value = context.ChefSocials.Where(x => x.ChefId == id).ToList();
            ViewBag.ChefId = id;
            return View(value);
        }
        [HttpGet]
        public ActionResult AddChefSocialMedia(int chefId)
        {
            var model = new ChefSocial
            {
                ChefId = chefId
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddChefSocialMedia(ChefSocial chefSocial)
        {
            context.ChefSocials.Add(chefSocial);
            context.SaveChanges();
            return RedirectToAction("Index", new { id = chefSocial.ChefId });
        }
        [HttpGet]
        public ActionResult UpdateChefSocialMedia(int id)
        {
            var value = context.ChefSocials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChefSocialMedia(ChefSocial chefSocial)
        {
            var value = context.ChefSocials.Find(chefSocial.ChefSocialId);
            value.SocialMediaName = chefSocial.SocialMediaName;
            value.Url = chefSocial.Url;
            value.Icon = chefSocial.Icon;
            context.SaveChanges();
            return RedirectToAction("Index", new { id = chefSocial.ChefId });
        }
        public ActionResult DeleteChefSocialMedia(int id)
        {
            var value = context.ChefSocials.Find(id);
            context.ChefSocials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index", new { id = value.ChefId });
        }
    }
}