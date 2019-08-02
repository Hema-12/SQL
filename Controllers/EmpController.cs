using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeApp.Models;
using System.Data;
using System.Data.Entity.Core.Objects;

namespace EmployeeApp.Controllers
{
    public class EmpController : Controller
    {
        EmpDBcontext db = new EmpDBcontext();

        public ActionResult Index()
        {
            return View(db.Emps.ToList());
        }

        public ActionResult SearchEmployees(Emp emp)
        {
            var EmployeeList = db.Emps.Where(e => e.FirstName == emp.FirstName).ToList();
            return View(EmployeeList);
        }

        public ActionResult Details(int id)
        {
            Models.Emp employee = db.Emps.Find(id);
          
            return View(employee);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Emp employee)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            Models.Emp employee = db.Emps.Find(id);

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Emp employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            Models.Emp employee = db.Emps.Find(id);
           
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp employee = db.Emps.Find(id);
            db.Emps.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
}
}