using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class TransactionsController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Transactions
        public ActionResult Index()
        {
            var values = db.TBLPROCESS.ToList();
            return View(values);
        }
    }
}