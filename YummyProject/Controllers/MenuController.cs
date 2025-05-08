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
    public class MenuController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categories = context.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            ViewBag.Categories = categories;

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (product.ImageFile != null)
            {
                var fileName = Path.GetFileName(product.ImageFile.FileName);
                var extension = Path.GetExtension(fileName).ToLower();

                var savePath = Path.Combine(Server.MapPath("~/images/"), extension);
                product.ImageFile.SaveAs(savePath);
                product.ImageUrl = "/images/" + extension;

            }

            ViewBag.Categories = context.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();


            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = context.Products.Find(id);

            ViewBag.Categories = context.Categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString(),
                Selected = (x.CategoryId == value.CategoryId)
            }).ToList();


            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            var value = context.Products.Find(product.ProductId);
            if (value == null)
            {
                return HttpNotFound();
            }

            if (product.ImageFile != null)
            {
                var fileName = Path.GetFileName(product.ImageFile.FileName);
                var extension = Path.GetExtension(fileName).ToLower();

                var savePath = Path.Combine(Server.MapPath("~/images/"), extension);
                product.ImageFile.SaveAs(savePath);
                value.ImageUrl = "/images/" + extension;

            }

            value.ProductName = product.ProductName;
            value.Ingredients = product.Ingredients;
            value.Price = product.Price;
            value.CategoryId = product.CategoryId;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}