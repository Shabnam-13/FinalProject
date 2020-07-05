using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class SubscribeController : Controller
    {
        // GET: Admin/Subscribe
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<Subscribe> messages = db.Subscribe.ToList();
            return View(messages);
        }

        public ActionResult Details(int? id)
        {
            Subscribe subs = db.Subscribe.Find(id);
            if (subs == null)
            {
                return HttpNotFound();
            }

            return View(subs);
        }

        public ActionResult Delete(int? id)
        {
            Subscribe subs = db.Subscribe.Find(id);
            if (subs == null)
            {
                return HttpNotFound();
            }
            db.Subscribe.Remove(subs);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}