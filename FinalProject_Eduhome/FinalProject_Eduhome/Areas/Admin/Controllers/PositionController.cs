using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class PositionController : Controller
    {
        // GET: Admin/Position
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<Position> positions = db.Positions.ToList();
            return View(positions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        public ActionResult Update(int? id)
        {
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        [HttpPost]
        public ActionResult Update(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        public ActionResult Delete(int? id, bool? a)
        {
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            db.Positions.Remove(position);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}