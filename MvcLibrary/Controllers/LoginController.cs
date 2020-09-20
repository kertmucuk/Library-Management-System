using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcLibrary.Controllers
{
    public class LoginController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLMEMBERS p)
        {
            var infos = db.TBLMEMBERS.FirstOrDefault(m => m.Mail == p.Mail && m.Password == p.Password);
            if(infos!=null)
            {
                FormsAuthentication.SetAuthCookie(infos.Mail, false);
                Session["Mail"] = infos.Mail.ToString();
                //TempData["Name"] = infos.Name.ToString();
                //TempData["ID"] = infos.ID.ToString();
                //TempData["LastName"] = infos.LastName.ToString();
                //TempData["Username"] = infos.UserName.ToString();
                //TempData["Password"] = infos.Password.ToString();
                //TempData["School"] = infos.School.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}