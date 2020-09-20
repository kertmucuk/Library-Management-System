using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class RegisterController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            var univesity = db.TBLUNIVERSITIES.ToList();
            return View(univesity);
        }
        [HttpPost]
        public ActionResult Register(TBLMEMBERS p)
        {
            if(!ModelState.IsValid)
            {
                return View("Register");
            }
            db.TBLMEMBERS.Add(p);
            db.SaveChanges();
            return View("Register");
        }
    }
}