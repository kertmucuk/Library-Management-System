using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class StatisticsController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Statistics
        public ActionResult Index()
        {
            var value1 = db.TBLMEMBERS.Count();
            ViewBag.value1 = value1;
            var value2 = db.TBLBOOK.Count();
            ViewBag.value2 = value2;
            var value3 = db.TBLBOOK.Where(b => b.State == false).Count();
            ViewBag.value3 = value3;
            var value4 = db.TBLPENALTIES.Sum(i => i.Charge);
            ViewBag.value4 = value4;
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            var books = db.TBLBOOK.ToList();
            return View(books);
        }
        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase fileBase)
        {
            if(fileBase.ContentLength>0)
            {
                string filepath = Path.Combine(Server.MapPath("~/web2/resimler/"),Path.GetFileName(fileBase.FileName));
                fileBase.SaveAs(filepath);
            }
            return RedirectToAction("Gallery");
        }
    }
}