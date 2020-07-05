using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Migrations;
using FinalProject_Eduhome.Models;
using FinalProject_Eduhome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class HomeController : Controller
    {
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.About = db.About.FirstOrDefault();

            HomeVM model = new HomeVM();
            model.Slides = db.Slide.ToList();
            model.Events = db.Events.Take(4).ToList();
            model.Courses = db.Courses.Take(3).ToList();
            model.Testimonials = db.Testimonials.ToList();
            model.Blogs = db.Blogs.Take(6).ToList();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Subscribe(SubscribeVM subscribe)
        {
            if (!string.IsNullOrEmpty(subscribe.Email))
            {
                if (db.Subscribe.Any(e => e.Email == subscribe.Email))
                {
                    Session["SameEmail"] = true;
                    if (subscribe.Page == "Home")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (subscribe.Page == "About")
                    {
                        return RedirectToAction("Index", "About");
                    }
                    else if (subscribe.Page == "Course")
                    {
                        return RedirectToAction("Index", "Course");
                    }
                    else if (subscribe.Page == "CourseDetails")
                    {
                        return RedirectToAction("Details", "Course", new { id = subscribe.ItemId });
                    }
                    else if (subscribe.Page == "Blog")
                    {
                        return RedirectToAction("Index", "Blog");
                    }
                    else if (subscribe.Page == "BlogDetails")
                    {
                        return RedirectToAction("Details", "Blog", new { id = subscribe.ItemId });
                    }
                    else if (subscribe.Page == "Event")
                    {
                        return RedirectToAction("Index", "Event");
                    }
                    else if (subscribe.Page == "EventDetails")
                    {
                        return RedirectToAction("Details", "Event", new { id = subscribe.ItemId });
                    }
                    else if (subscribe.Page == "Contact")
                    {
                        return RedirectToAction("Index", "Contact");
                    }
                    else if (subscribe.Page == "Teacher")
                    {
                        return RedirectToAction("Index", "Teacher");
                    }
                    else if (subscribe.Page == "TeacherDetails")
                    {
                        return RedirectToAction("Details", "Teacher", new { id = subscribe.ItemId });
                    }
                    else if (subscribe.Page == "Login")
                    {
                        return RedirectToAction("Login", "User");
                    }
                    else if (subscribe.Page == "SignUp")
                    {
                        return RedirectToAction("SingUp", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                Subscribe Subscribe = new Subscribe();
                Subscribe.Email = subscribe.Email;
                Subscribe.CreatedDate = DateTime.Now;

                db.Subscribe.Add(Subscribe);
                db.SaveChanges();

                Session["SuccessfullSubscribe"] = true;
                if (subscribe.Page == "Home")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (subscribe.Page == "About")
                {
                    return RedirectToAction("Index", "About");
                }
                else if (subscribe.Page == "Course")
                {
                    return RedirectToAction("Index", "Course");
                }
                else if (subscribe.Page == "CourseDetails")
                {
                    return RedirectToAction("Details", "Course", new { id = subscribe.ItemId });
                }
                else if (subscribe.Page == "Blog")
                {
                    return RedirectToAction("Index", "Blog");
                }
                else if (subscribe.Page == "BlogDetails")
                {
                    return RedirectToAction("Details", "Blog", new { id = subscribe.ItemId });
                }
                else if (subscribe.Page == "Event")
                {
                    return RedirectToAction("Index", "Event");
                }
                else if (subscribe.Page == "EventDetails")
                {
                    return RedirectToAction("Details", "Event", new { id = subscribe.ItemId });
                }
                else if (subscribe.Page == "Contact")
                {
                    return RedirectToAction("Index", "Contact");
                }
                else if (subscribe.Page == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");
                }
                else if (subscribe.Page == "TeacherDetails")
                {
                    return RedirectToAction("Details", "Teacher", new { id = subscribe.ItemId });
                }
                else if (subscribe.Page == "Login")
                {
                    return RedirectToAction("Login", "User");
                }
                else if (subscribe.Page == "SignUp")
                {
                    return RedirectToAction("SingUp", "User");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            Session["EmptyEmail"] = true;
            if (subscribe.Page == "Home")
            {
                return RedirectToAction("Index", "Home");
            }
            else if (subscribe.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }
            else if (subscribe.Page == "Course")
            {
                return RedirectToAction("Index", "Course");
            }
            else if (subscribe.Page == "CourseDetails")
            {
                return RedirectToAction("Details", "Course", new { id = subscribe.ItemId });
            }
            else if (subscribe.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }
            else if (subscribe.Page == "BlogDetails")
            {
                return RedirectToAction("Details", "Blog", new { id = subscribe.ItemId });
            }
            else if (subscribe.Page == "Event")
            {
                return RedirectToAction("Index", "Event");
            }
            else if (subscribe.Page == "EventDetails")
            {
                return RedirectToAction("Details", "Event", new { id = subscribe.ItemId });
            }
            else if (subscribe.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else if (subscribe.Page == "Teacher")
            {
                return RedirectToAction("Index", "Teacher");
            }
            else if (subscribe.Page == "TeacherDetails")
            {
                return RedirectToAction("Details", "Teacher", new { id = subscribe.ItemId });
            }
            else if (subscribe.Page == "Login")
            {
                return RedirectToAction("Login", "User");
            }
            else if (subscribe.Page == "SignUp")
            {
                return RedirectToAction("SingUp", "User");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Message(MessageVM message)
        {
            if (!string.IsNullOrEmpty(message.Email) && !string.IsNullOrEmpty(message.Name))
            {
                if(!string.IsNullOrEmpty(message.Content))
                {
                    Message Message = new Message();
                    Message.Name = message.Name;
                    Message.Email = message.Email;
                    Message.Subject = message.Subject;
                    Message.Content = message.Content;
                    Message.SendDate = DateTime.Now;

                    db.Messages.Add(Message);
                    db.SaveChanges();

                    Session["SuccessfullMessage"] = true;
                    if (message.Page == "CourseDetails")
                    {
                        return RedirectToAction("Details", "Course", new { id = message.ItemId });
                    }
                    else if (message.Page == "BlogDetails")
                    {
                        return RedirectToAction("Details", "Blog", new { id = message.ItemId });
                    }
                    else if (message.Page == "EventDetails")
                    {
                        return RedirectToAction("Details", "Event", new { id = message.ItemId });
                    }
                    else if (message.Page == "Contact")
                    {
                        return RedirectToAction("Index", "Contact");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                Session["EmptySbjectOrContent"] = true;
                if (message.Page == "CourseDetails")
                {
                    return RedirectToAction("Details", "Course", new { id = message.ItemId });
                }
                else if (message.Page == "BlogDetails")
                {
                    return RedirectToAction("Details", "Blog", new { id = message.ItemId });
                }
                else if (message.Page == "EventDetails")
                {
                    return RedirectToAction("Details", "Event", new { id = message.ItemId });
                }
                else if (message.Page == "Contact")
                {
                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            Session["EmptyEmailOrName"] = true;
            if (message.Page == "CourseDetails")
            {
                return RedirectToAction("Details", "Course", new { id = message.ItemId });
            }
            else if (message.Page == "BlogDetails")
            {
                return RedirectToAction("Details", "Blog", new { id = message.ItemId });
            }
            else if (message.Page == "EventDetails")
            {
                return RedirectToAction("Details", "Event", new { id = message.ItemId });
            }
            else if (message.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}