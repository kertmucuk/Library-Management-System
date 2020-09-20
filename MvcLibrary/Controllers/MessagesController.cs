using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MvcLibrary.Controllers
{
    public class MessagesController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Messages
        [Authorize]
        public ActionResult Index()
        {

            var mail = Session["Mail"].ToString();
            var messages = db.TBLMESSAGES.Where(m => m.Receiver == mail).ToList();
            var values = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == mail);
            ViewBag.fullname = values.Name + " " + values.LastName;
            return View(messages);
        }
        [Authorize]
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = Session["Mail"].ToString();
            var values = db.TBLMEMBERS.FirstOrDefault(x => x.Mail == mail);
            ViewBag.fullname = values.Name + " " + values.LastName;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult NewMessage(TBLMESSAGES m)
        {
            m.Sender = Session["Mail"].ToString();
            m.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.TBLMESSAGES.Add(m);
            db.SaveChanges();
            return RedirectToAction("SentMessages","Messages");
        }
        [Authorize]
        public ActionResult SentMessages()
        {
            var mail = Session["Mail"].ToString();
            var values = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == mail);
            ViewBag.fullname = values.Name + " " + values.LastName;
            var messages = db.TBLMESSAGES.Where(m => m.Sender == mail).ToList();
            return View(messages);
        }
    }
}