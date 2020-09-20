using MvcLibrary.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using Microsoft.Ajax.Utilities;

namespace MvcLibrary.Controllers
{
    public class MemberController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Member
        public ActionResult Index(int page=1)
        {

            //var members = db.TBLMEMBERS.ToList();
            var values = db.TBLMEMBERS.ToList().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddNewMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewMember(TBLMEMBERS p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewMember");
            }
            db.TBLMEMBERS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMember(int id)
        {
            var member = db.TBLMEMBERS.Find(id);
            db.TBLMEMBERS.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnMember(int id)
        {
            var member = db.TBLMEMBERS.Find(id);
            return View("ReturnMember", member);
        }
        public ActionResult UpdateMember(TBLMEMBERS p)
        {
            var member = db.TBLMEMBERS.Find(p.ID);
            member.Name = p.Name;
            member.LastName = p.LastName;
            member.Mail = p.Mail;
            member.UserName = p.UserName;
            member.Password = p.Password;
            member.Telephone = p.Telephone;
            member.Photo = p.Photo;
            member.School = p.School;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookHistory(int id)
        {
            var member = db.TBLMEMBERS.Find(id);
            ViewBag.name = member.Name + " " + member.LastName;
            var books = db.TBLPROCESS.Where(p => p.Member == member.ID).ToList();
            return View(books);
        }
    }
}