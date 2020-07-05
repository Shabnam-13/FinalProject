using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Admin/Messages
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<Message> messages = db.Messages.ToList();
            return View(messages);
        }

        public ActionResult Details(int? id)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }

        public ActionResult Delete(int? id)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            db.Messages.Remove(message);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}