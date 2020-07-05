using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Migrations;
using FinalProject_Eduhome.Models;
using FinalProject_Eduhome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        EduhomeDB db = new EduhomeDB();
        public ActionResult SingUp()
        {
            ViewBag.About = db.About.FirstOrDefault();
            return View();
        }


        [HttpPost]
        public ActionResult SingUp(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(e => e.Email == user.Email))
                {
                    ViewBag.About = db.About.FirstOrDefault();
                    ModelState.AddModelError("Email", "This email already exists");
                    return View(user);
                }
                if (db.Users.Any(e => e.Username == user.Username))
                {
                    ViewBag.About = db.About.FirstOrDefault();
                    ModelState.AddModelError("Username", "This Username already exists");
                    return View(user);
                }

                User usr = new User();
                usr.Name = user.Name;
                usr.Surname = user.Surname;
                usr.Username = user.Username;
                usr.Email = user.Email;
                usr.Password = Crypto.HashPassword(user.Password);
                usr.CreatedDate = DateTime.Now;

                db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.About = db.About.FirstOrDefault();
            return View(user);
        }

        public ActionResult Login()
        {
            ViewBag.About = db.About.FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {

            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(a => a.Username == login.Username);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password))
                    {
                        Session["User"] = user;
                        Session["UserId"] = user.Id;

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

            ViewBag.About = db.About.FirstOrDefault();
            return View(login);
        }
    }
}