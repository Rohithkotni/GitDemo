using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportManagementSystem.Models;

namespace AirportManagementSystem.Controllers
{
    public class CrudRegistrationController : Controller
    {
        private AirportManagementSystemContext db = new AirportManagementSystemContext();

        
        // GET: CrudRegistration
        public ActionResult List()
        {
            var output = db.Registrations.ToList();
            return View("List",output);
        }

        // GET: CrudRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: CrudRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName,Gender,DOB,ContactNumber,Password,ConfirmPassword,Designation,SecurityQuestion1,SecurityQuestion2,SecurityQuestion3,Active")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registration);
        }

        // GET: CrudRegistration/Edit/5
        public ActionResult Approve(int? id)
        {
            if (id != null)
            {
                var registration = db.Registrations.FirstOrDefault(x => x.EmployeeId == id);
                //Registration registration = db.Registrations.Find(id);
                if (registration != null)
                {
                    registration.Active = true;
                    db.SaveChanges();
                    ViewBag.Message = "Approved Successfully";
                    return View("SuccessfullyUpdated");
                }
                return View("Error");
            }
            return View("Error");
            
           
        }

        public ActionResult Deny(int? id)
        {
            if (id != null)
            {
                var registration = db.Registrations.FirstOrDefault(x => x.EmployeeId == id);
                //Registration registration = db.Registrations.Find(id);
                if (registration != null)
                {
                    registration.Active = false;
                    db.SaveChanges();
                    ViewBag.Message = "Denied the Request";
                    return View("SuccessfullyUpdated");
                }
                return View("Error");
            }
            return View("Error");


        }

        // POST: CrudRegistration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,Gender,DOB,ContactNumber,Password,ConfirmPassword,Designation,SecurityQuestion1,SecurityQuestion2,SecurityQuestion3,Active")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registration);
        }

        // GET: CrudRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: CrudRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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
