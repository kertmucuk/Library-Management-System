using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class AuthorController : Controller
    {
        DBLibraryEntities entities = new DBLibraryEntities();
        // GET: Author
        public ActionResult Index()
        {
            var values = entities.TBLAUTHOR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddNewAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewAuthor(TBLAUTHOR p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddNewAuthor");
            }
            entities.TBLAUTHOR.Add(p);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAuthor(int id)
        {
            var author = entities.TBLAUTHOR.Find(id);
            entities.TBLAUTHOR.Remove(author);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnAuthor(int id)
        {
            var author = entities.TBLAUTHOR.Find(id);
            return View("ReturnAuthor", author);
        }
        public ActionResult UpdateAuthor(TBLAUTHOR p)
        {
            var author = entities.TBLAUTHOR.Find(p.ID);
            author.Name = p.Name;
            author.LastName = p.LastName;
            author.Detail = p.Detail;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBooks(int id)
        {
            var author = entities.TBLAUTHOR.Find(id);
            ViewBag.name = author.Name + " " + author.LastName;
            var books = entities.TBLBOOK.Where(b => b.TBLAUTHOR.ID == author.ID).ToList();
            return View(books);
        }
    }
}