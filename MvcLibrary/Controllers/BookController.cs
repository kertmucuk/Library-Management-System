using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class BookController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Book
        public ActionResult Index(string p)
        {
            var book = from b in db.TBLBOOK select b;
            if(!string.IsNullOrEmpty(p)) { book = book.Where(b => b.Name.Contains(p)); }
            //var book = db.TBLBOOK.ToList();
            return View(book.ToList());
        }
        [HttpGet]
        public ActionResult AddNewBook()
        {
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.ID.ToString()

                                          }).ToList();
            ViewBag.value1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name +" "+ i.LastName,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.value2 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBook(TBLBOOK p)
        {
            var category = db.TBLCATEGORY.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var author = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            p.TBLCATEGORY = category;
            p.TBLAUTHOR = author;
            p.State = true;
            db.TBLBOOK.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var book = db.TBLBOOK.Find(id);
            db.TBLBOOK.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnBook(int id)
        {
            var book = db.TBLBOOK.Find(id);
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.value1 = value1;
            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + " " + i.LastName,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.value2 = value2;
            return View("ReturnBook", book);
        }
        public ActionResult UpdateBook(TBLBOOK p)
        {
            var book = db.TBLBOOK.Find(p.ID);
            book.Name = p.Name;
            book.PrintDate = p.PrintDate;
            book.Page = p.Page;
            book.Publisher = p.Publisher;
            var category = db.TBLCATEGORY.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var author = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            book.Category = category.ID;
            book.Author = author.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}