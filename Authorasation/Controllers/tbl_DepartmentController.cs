using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Authorasation.Models;

namespace Authorasation.Controllers
{
    public class tbl_DepartmentController : Controller
    {
        private EmployeeEntities3 db = new EmployeeEntities3();

        [Authorize(Roles ="V,A")]
        // GET: tbl_Department
        public ActionResult Index()
        {
            return View(db.tbl_Department.ToList());
        }

        // GET: tbl_Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // GET: tbl_Department/Create

        [Authorize(Roles = "A")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Did,DName,HOD,Depid")] tbl_Department tbl_Department)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Department.Add(tbl_Department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Department);
        }

        // GET: tbl_Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // POST: tbl_Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Did,DName,HOD,Depid")] tbl_Department tbl_Department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Department);
        }

        // GET: tbl_Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            if (tbl_Department == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Department);
        }

        // POST: tbl_Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Department tbl_Department = db.tbl_Department.Find(id);
            db.tbl_Department.Remove(tbl_Department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
