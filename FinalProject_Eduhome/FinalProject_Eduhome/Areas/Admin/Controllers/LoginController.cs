using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_Eduhome.Models;
using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Migrations;
using System.Web.Helpers;
using FinalProject_Eduhome.Areas.Admin.ViewModels;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        EduhomeDB db = new EduhomeDB();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                EduAdmin admin = db.EduAdmin.FirstOrDefault(a => a.Username == login.Username);
                if (admin != null)
                {
                    if (Crypto.VerifyHashedPassword(admin.Password, login.Password))
                    {
                        Session["Admin"] = admin;
                        Session["AdminId"] = admin.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Incorrect username");
                }
            }
            return View(login);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(EduAdmin admin)
        {
            if (ModelState.IsValid)
            {
                if (db.EduAdmin.Any(e => e.Email == admin.Email))
                {
                    ModelState.AddModelError("Email", "This email already exists");
                    return View(admin);
                }
                if (db.EduAdmin.Any(e => e.Username == admin.Username))
                {
                    ModelState.AddModelError("Username", "This Username already exists");
                    return View(admin);
                }

                EduAdmin adm = new EduAdmin();
                adm.Name = admin.Name;
                adm.Surname = admin.Surname;
                adm.Username = admin.Username;
                adm.Email = admin.Email;
                adm.Password = Crypto.HashPassword(admin.Password);
                adm.CreatedDate = DateTime.Now;

                db.EduAdmin.Add(adm);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["AdminId"] = null;
           
            return RedirectToAction("Login","Login");
        }
    }
}