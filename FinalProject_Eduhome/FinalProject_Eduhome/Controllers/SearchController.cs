using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using FinalProject_Eduhome.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        EduhomeDB db = new EduhomeDB();
        public ActionResult Events()
        {
            ViewBag.About = db.About.FirstOrDefault();
            List<Event> events = TempData["data"] as List<Event>;
            return View(events);
        }

        public ActionResult Blogs()
        {
            ViewBag.About = db.About.FirstOrDefault();
            List<Blog> blogs = TempData["data"] as List<Blog>;
            return View(blogs);
        }

        public ActionResult Courses()
        {
            ViewBag.About = db.About.FirstOrDefault();
            List<Course> courses = TempData["data"] as List<Course>;
            return View(courses);
        }

        [HttpPost]
        public ActionResult Search(SearchVM search)
        {
            if (search.SearchText != null)
            {
                if (search.Page == "Event")
                {
                    List<Event> events = new List<Event>();
                    events = db.Events.Where(t => t.Title.Contains(search.SearchText)).ToList();

                    TempData["data"] = events;
                    return RedirectToAction("Events");
                   
                }
                else if(search.Page == "Blog")
                {
                    List<Blog> blogs = new List<Blog>();
                    blogs = db.Blogs.Where(t => t.Title.Contains(search.SearchText)).ToList();

                    TempData["data"] = blogs;
                    return RedirectToAction("Blogs");
                }
                else if(search.Page == "Course")
                {
                    List<Course> courses = new List<Course>();
                    courses = db.Courses.Where(t => t.Name.Contains(search.SearchText)).ToList();

                    TempData["data"] = courses;
                    return RedirectToAction("Courses");
                }
            }
            ViewBag.About = db.About.FirstOrDefault();
            return View();
        }
    }
}