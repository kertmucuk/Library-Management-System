using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class AnnouncementsController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Announcements
        public ActionResult Index()
        {
            var announcements = db.TBLAnnouncements.ToList();
            return View(announcements);
        }
        [HttpGet]
        public ActionResult AddNewAnnouncements()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewAnnouncements(TBLAnnouncements p)
        {
            db.TBLAnnouncements.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnnouncements(int id)
        {
            var anno = db.TBLAnnouncements.Find(id);
            db.TBLAnnouncements.Remove(anno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnAnnouncements(int id)
        {
            var anno = db.TBLAnnouncements.Find(id);
            return View("ReturnAnnouncements", anno);
        }
        public ActionResult AnnouncementsContents(int id)
        {
            var anno = db.TBLAnnouncements.Find(id);
            ViewBag.id = anno.ID;
            return View("AnnouncementsContents", anno);
        }
        public ActionResult UpdateAnnouncements(TBLAnnouncements p)
        {
            var anno = db.TBLAnnouncements.Find(p.ID);
            anno.Category = p.Category;
            anno.Content = p.Content;
            anno.Date = p.Date;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult MemberAnnouncements()
        {
            var membermail = Session["Mail"].ToString();
            var values = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == membermail);
            ViewBag.fullname = values.Name + " " + values.LastName;
            var annos = db.TBLAnnouncements.ToList();
            return View(annos);
        }
        [Authorize]
        public ActionResult MemberAnnouncementsContents(int id)
        {
            var membermail = Session["Mail"].ToString();
            var values = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == membermail);
            ViewBag.fullname = values.Name + " " + values.LastName;
            var anno = db.TBLAnnouncements.Find(id);
            ViewBag.id = anno.ID;
            return View("MemberAnnouncementsContents", anno);
        }
    }
}