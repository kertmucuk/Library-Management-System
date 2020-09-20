using MvcLibrary.Models.Class;
using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class ShowCaseController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        Class1 class1 = new Class1();
        // GET: ShowCase
        [HttpGet]
        public ActionResult Index()
        {
            //var values = db.TBLBOOK.ToList();
            class1.bookprop = db.TBLBOOK.ToList();
            class1.aboutprop = db.TBLABOUT.ToList();
            return View(class1);
        }
        [HttpPost]
        public ActionResult Index(TBLContact c)
        {
            db.TBLContact.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}