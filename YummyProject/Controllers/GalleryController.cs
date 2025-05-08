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
    public class GalleryController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.PhotoGalleries.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdatePhoto(int id)
        {
            var values = context.PhotoGalleries.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdatePhoto(PhotoGallery photoGallery)
        {
            var value = context.PhotoGalleries.Find(photoGallery.PhotoGalleryId);

            if (photoGallery.ImageFile != null)
            {
                var fileName = Path.GetFileName(photoGallery.ImageFile.FileName);
                var savePath = Path.Combine(Server.MapPath("/images/"), fileName);
                photoGallery.ImageFile.SaveAs(savePath);
                value.ImageUrl = "/images/" + fileName;
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeletePhoto(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            context.PhotoGalleries.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto(PhotoGallery photoGallery)
        {
            if (photoGallery.ImageFile != null)
            {
                var fileName = Path.GetFileName(photoGallery.ImageFile.FileName);
                var savePath = Path.Combine(Server.MapPath("/images/"), fileName);
                photoGallery.ImageFile.SaveAs(savePath);
                photoGallery.ImageUrl = "/images/" + fileName;
            }
            context.PhotoGalleries.Add(photoGallery);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}