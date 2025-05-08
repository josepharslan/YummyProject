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
    public class TestimonialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var value = context.Testimonials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Testimonial testimonial)
        {
            var filename = Path.GetFileName(testimonial.ImageFile.FileName);
            var savepath = Path.Combine(Server.MapPath("~/images/"), filename);
            testimonial.ImageFile.SaveAs(savepath);
            testimonial.ImageUrl = "/images/" + filename;

            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Testimonial testimonial)
        {
            var value = context.Testimonials.Find(testimonial.TestimonialId);

            if (testimonial.ImageFile != null)
            {
                var filename = Path.GetFileName(testimonial.ImageFile.FileName);
                var savepath = Path.Combine(Server.MapPath("~/images/"), filename);
                testimonial.ImageFile.SaveAs(savepath);
                value.ImageUrl = "/images/" + filename;
            }

            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.Comment = testimonial.Comment;
            value.Rating = testimonial.Rating;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}