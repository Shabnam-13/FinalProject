using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                int adminId = (int)Session["AdminId"];
                EduAdmin admin = db.EduAdmin.Find(adminId);

                return View(admin);
            }
            return RedirectToAction("Login", "Login");
        }
    }
}