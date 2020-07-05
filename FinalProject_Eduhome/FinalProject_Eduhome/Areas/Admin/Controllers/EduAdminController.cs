using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class EduAdminController : Controller
    {
        // GET: Admin/EduAdmin
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<EduAdmin> admin = db.EduAdmin.ToList();
            return View(admin);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EduAdmin admin)
        {
            if (ModelState.IsValid)
            {
                EduAdmin adm = new EduAdmin();
                if (db.EduAdmin.Any(a => a.Email == admin.Email))
                {
                    ModelState.AddModelError("Email", "This email already exists");
                    return View(admin);
                }
                if (db.EduAdmin.Any(a => a.Username == admin.Username))
                {
                    ModelState.AddModelError("Username", "This Username already exists");
                    return View(admin);
                }
                if (admin.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + admin.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    admin.ImageFile.SaveAs(imagePath);
                    adm.Image = imageName;
                }
                adm.Name = admin.Name;
                adm.Surname = admin.Surname;
                adm.Username = admin.Username;
                adm.Email = admin.Email;
                adm.Password = Crypto.HashPassword(admin.Password);
                adm.CreatedDate = DateTime.Now;

                db.EduAdmin.Add(adm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        public ActionResult Delete (int? id)
        {
            EduAdmin admin = db.EduAdmin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            if (admin.Image != null)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), admin.Image);
                System.IO.File.Delete(oldPath);
            }
            db.EduAdmin.Remove(admin);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}