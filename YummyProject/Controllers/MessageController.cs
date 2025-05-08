using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class MessageController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var value = context.Messages.OrderByDescending(x => x.MessageId).ToList();
            return View(value);
        }
        public ActionResult Read()
        {
            var value = context.Messages.Where(x => x.IsRead == true).OrderByDescending(x => x.MessageId).ToList();
            return View(value);
        }
        public ActionResult NotRead()
        {
            var value = context.Messages.Where(x => x.IsRead == false).OrderByDescending(x => x.MessageId).ToList();
            return View(value);
        }
        public ActionResult ReadMore(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }
    }
}