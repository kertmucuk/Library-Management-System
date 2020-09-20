using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    public class PanelController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Panel
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var membermail = Session["Mail"].ToString();
            var values = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == membermail);
            ViewBag.fullname = values.Name + " " + values.LastName;
            return View(values);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index2(TBLMEMBERS p)
        {
            var member = (string)Session["Mail"];
            var infos = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == member);
            infos.Password = p.Password;
            infos.Name = p.Name;
            infos.Mail = p.Mail;
            infos.LastName = p.LastName;
            infos.Photo = p.Photo;
            infos.Telephone = p.Telephone;
            infos.UserName = p.UserName;
            infos.School = p.School;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult MyBooks()
        {
            var member = Session["Mail"].ToString();
            var values = db.TBLMEMBERS.FirstOrDefault(x => x.Mail == member);
            ViewBag.fullname = values.Name + " " + values.LastName;
            var infos = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == member);
            var process = db.TBLPROCESS.Where(p => p.Member == infos.ID).ToList();
            return View(process);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}