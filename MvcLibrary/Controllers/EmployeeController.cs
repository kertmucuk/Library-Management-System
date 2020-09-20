using MvcLibrary.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibrary.Controllers
{
    public class EmployeeController : Controller
    {
        DBLibraryEntities db = new DBLibraryEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var employee = db.TBLEMPLOYEE.ToList();
            return View(employee);
        }
        [HttpGet]
        public ActionResult AddNewEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewEmployee(TBLEMPLOYEE p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewEmployee");
            }
            db.TBLEMPLOYEE.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.TBLEMPLOYEE.Find(id);
            db.TBLEMPLOYEE.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnEmployee(int id)
        {
            var employee = db.TBLEMPLOYEE.Find(id);
            return View("ReturnEmployee",employee);
        }
        public ActionResult UpdateEmployee(TBLEMPLOYEE p)
        {
            var employee = db.TBLEMPLOYEE.Find(p.ID);
            employee.Employee = p.Employee;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}