using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class BorrowController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Borrow
        public ActionResult Index()
        {
            var values = db.TBLPROCESS.Where(p => p.ProcessState == true).OrderBy(p => p.BorrowBack).ToList();
            return View(values);
        }
        public ActionResult BorrowBook(int id)
        {
            var borrow = db.TBLPROCESS.Find(id);
            DateTime d1 = Convert.ToDateTime(borrow.RETURNDATE);
            DateTime d2 = Convert.ToDateTime(borrow.BorrowBack);
            TimeSpan d3 = d2 - d1;
            ViewBag.value = d3.TotalDays;
            return View("BorrowBook", borrow);
        }
        public ActionResult BorrowBack(TBLPROCESS p)
        {
            var book = db.TBLBOOK.Where(b => b.ID == p.TBLBOOK.ID).FirstOrDefault();
            var process = db.TBLPROCESS.Where(z => z.ID == p.ID).FirstOrDefault();
            book.State = true;
            process.ProcessState = true;
            process.BorrowBack = p.BorrowBack;
            DateTime d1 = Convert.ToDateTime(process.RETURNDATE);
            DateTime d2 = Convert.ToDateTime(process.BorrowBack);
            TimeSpan d3 = d2 - d1;
            double numberofdays = d3.TotalDays;
            if(!(numberofdays<0 || numberofdays==0))
            {
                TBLPENALTIES tbl = new TBLPENALTIES();
                tbl.Member = process.Member;
                tbl.Process = process.ID;
                tbl.Starttime = process.DATEOFPURCHASE;
                tbl.Endtime = process.BorrowBack;
                tbl.Charge = Convert.ToDecimal(numberofdays * 0.25);
                db.TBLPENALTIES.Add(tbl);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Lending");
        }
    }
}