using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Admin/Teachers
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            ViewBag.Faculty = db.Faculties.ToList();
            ViewBag.Position = db.Positions.ToList();
            List<Teachers> teachers = db.Teachers.ToList();
            return View(teachers);
        }

        public ActionResult Create()
        {
            ViewBag.Faculty = db.Faculties.ToList();
            ViewBag.Position = db.Positions.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                if (teachers.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teachers.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    teachers.ImageFile.SaveAs(imagePath);
                    teachers.Image = imageName;
                }
                else
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    ViewBag.Position = db.Positions.ToList();
                    ViewBag.Faculty = db.Faculties.ToList();
                    return View(teachers);
                }

                db.Teachers.Add(teachers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Position = db.Positions.ToList();
            ViewBag.Faculty = db.Faculties.ToList();
            return View(teachers);
        }

        public ActionResult Update(int? id)
        {
            ViewBag.Position = db.Positions.ToList();
            ViewBag.Faculty = db.Faculties.ToList();
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        [HttpPost]
        public ActionResult Update(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                Teachers teach = db.Teachers.Find(teachers.Id);

                if (teachers.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teachers.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), teach.Image);
                    System.IO.File.Delete(oldImagePath);

                    teachers.ImageFile.SaveAs(imagePath);
                    teach.Image = imageName;
                }
                teach.FullName = teachers.FullName;
                teach.PositionId = teachers.PositionId;
                teach.FacultyId = teachers.FacultyId;
                teach.About = teachers.About;
                teach.Degree = teachers.Degree;
                teach.Experience = teachers.Experience;
                teach.Hobbies = teachers.Hobbies;

                db.Entry(teach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Position = db.Positions.ToList();
            ViewBag.Faculty = db.Faculties.ToList();
            return View(teachers);
        }

        public ActionResult Delete(int? id)
        {
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }

            string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), teachers.Image);
            System.IO.File.Delete(oldPath);

            db.Teachers.Remove(teachers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}