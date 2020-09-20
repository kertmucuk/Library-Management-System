using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLibrary.Models.Entity;

namespace MvcLibrary.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLibraryEntities entities = new DBLibraryEntities();
        public ActionResult Index()
        {
            var values = entities.TBLCATEGORY.Where(c => c.State == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddNewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCategory(TBLCATEGORY p)
        {
            entities.TBLCATEGORY.Add(p);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = entities.TBLCATEGORY.Find(id);
            category.State = false;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnCategory(int id)
        {
            var category = entities.TBLCATEGORY.Find(id);
            return View("ReturnCategory", category);
        }
        public ActionResult UpdateCategory(TBLCATEGORY p)
        {
            var category = entities.TBLCATEGORY.Find(p.ID);
            category.CategoryName = p.CategoryName;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}