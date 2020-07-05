using FinalProject_Eduhome.DAL;
using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_Eduhome.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin/About
        EduhomeDB db = new EduhomeDB();
        public ActionResult Index()
        {
            List<About> about = db.About.ToList();
            return View(about);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                if (about.LogoFile == null)
                {
                    ModelState.AddModelError("LogoFile", "Image is required");
                    return View(about);
                }
                else
                {
                    string LogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.LogoFile.FileName;
                    string LogoPath = Path.Combine(Server.MapPath("~/Uploads/"), LogoName);

                    about.LogoFile.SaveAs(LogoPath);
                    about.Logo = LogoName;
                }

                if (about.IconFile == null && about.IconWhiteFile == null)
                {
                    ModelState.AddModelError("", "Icons is required");
                    return View(about);
                }
                else
                {
                    string IconName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.IconFile.FileName;
                    string IconPath = Path.Combine(Server.MapPath("~/Uploads/"), IconName);

                    string IconWName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.IconWhiteFile.FileName;
                    string IconWPath = Path.Combine(Server.MapPath("~/Uploads/"), IconWName);

                    about.IconFile.SaveAs(IconPath);
                    about.Icon = IconName; 
                    about.IconWhiteFile.SaveAs(IconWPath);
                    about.IconWhite = IconWName;
                }

                if (about.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    return View(about);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    about.ImageFile.SaveAs(imagePath);
                    about.Image = imageName;
                }

                if (about.PrllxImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    return View(about);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.PrllxImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    about.PrllxImageFile.SaveAs(imagePath);
                    about.PrllxImage = imageName;
                }

                if (about.BgImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required");
                    return View(about);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.BgImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    about.BgImageFile.SaveAs(imagePath);
                    about.BgImage = imageName;
                }

                db.About.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        public ActionResult Update(int? id)
        {
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        [HttpPost]
        public ActionResult Update(About about)
        {
            if (ModelState.IsValid)
            {
                About About = db.About.Find(about.Id);
                if (about.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), About.Image);
                    System.IO.File.Delete(oldPath);

                    about.ImageFile.SaveAs(imagePath);
                    About.Image = imageName;
                }

                if (about.LogoFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.LogoFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), About.Logo);
                    System.IO.File.Delete(oldPath);

                    about.LogoFile.SaveAs(imagePath);
                    About.Logo = imageName;
                }

                if (about.IconFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.IconFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), About.Icon);
                    System.IO.File.Delete(oldPath);

                    about.IconFile.SaveAs(imagePath);
                    About.Icon = imageName;
                }

                if (about.IconWhiteFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.IconWhiteFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), About.IconWhite);
                    System.IO.File.Delete(oldPath);

                    about.IconWhiteFile.SaveAs(imagePath);
                    About.IconWhite = imageName;
                }

                if (about.BgImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.BgImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), About.BgImage);
                    System.IO.File.Delete(oldPath);

                    about.BgImageFile.SaveAs(imagePath);
                    About.BgImage = imageName;
                }

                if (about.PrllxImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.PrllxImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads/"), About.PrllxImage);
                    System.IO.File.Delete(oldPath);

                    about.PrllxImageFile.SaveAs(imagePath);
                    About.PrllxImage = imageName;
                }

                About.Title = about.Title;
                About.Content = about.Content;
                About.VideoLink = about.VideoLink;
                About.Copyright = about.Copyright;

                db.Entry(About).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        public ActionResult Delete(int? id)
        {
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            string oldImPath = Path.Combine(Server.MapPath("~/Uploads/"), about.Image);
            System.IO.File.Delete(oldImPath);

            string oldLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), about.Logo);
            System.IO.File.Delete(oldLogoPath);

            string oldIcPath = Path.Combine(Server.MapPath("~/Uploads/"), about.Icon);
            System.IO.File.Delete(oldIcPath);

            string oldIWPath = Path.Combine(Server.MapPath("~/Uploads/"), about.IconWhite);
            System.IO.File.Delete(oldIWPath);

            string oldBgPath = Path.Combine(Server.MapPath("~/Uploads/"), about.BgImage);
            System.IO.File.Delete(oldBgPath);

            string oldPrPath = Path.Combine(Server.MapPath("~/Uploads/"), about.PrllxImage);
            System.IO.File.Delete(oldPrPath);

            db.About.Remove(about);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}