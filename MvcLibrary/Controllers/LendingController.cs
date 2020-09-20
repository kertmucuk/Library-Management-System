using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class LendingController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Lending
        public ActionResult Index()
        {
            var values = db.TBLPROCESS.Where(p => p.ProcessState == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult toLend()
        {
            List<SelectListItem> value1 = (from i in db.TBLBOOK.Where(b=>b.State==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.value1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLMEMBERS.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name+" "+i.LastName,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.value2 = value2;
            List<SelectListItem> value3= (from i in db.TBLEMPLOYEE.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Employee,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.value3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult toLend(TBLPROCESS p)
        {
            var member = db.TBLMEMBERS.Where(c => c.ID == p.TBLMEMBERS.ID).FirstOrDefault();
            var book = db.TBLBOOK.Where(a => a.ID == p.TBLBOOK.ID).FirstOrDefault();
            var employee = db.TBLEMPLOYEE.Where(e => e.ID == p.TBLEMPLOYEE.ID).FirstOrDefault();
            if(book.State==true)
            {
                p.TBLBOOK = book;
                book.State = false;
                p.TBLMEMBERS = member;
                p.TBLEMPLOYEE = employee;
                db.TBLPROCESS.Add(p);
                p.ProcessState = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("toLend");
        }

    }
}