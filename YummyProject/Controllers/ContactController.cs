using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ContactController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.ContactInfos.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(ContactInfo contact)
        {
            context.ContactInfos.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = context.ContactInfos.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(ContactInfo contact)
        {
            var value = context.ContactInfos.Find(contact.ContactInfoId);
            value.PhoneNumber = contact.PhoneNumber;
            value.Address = contact.Address;
            value.Email = contact.Email;
            value.MapUrl = contact.MapUrl;
            value.OpenHours = contact.OpenHours;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteContact(int id)
        {
            var value = context.ContactInfos.Find(id);
            context.ContactInfos.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}