using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/Users
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<User> users = db.Users.ToList();
            return View(users);
        }

        public ActionResult Delete(int? id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}