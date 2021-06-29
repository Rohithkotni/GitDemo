using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using AirportManagementSystem.Models;

namespace AirportManagementSystem.Controllers
{
    public class RegistrationsController : Controller
    {
        AirportManagementSystemContext context = new AirportManagementSystemContext();
        public ActionResult Create()
        {
            int count = (from row in context.Registrations select row).Count();
            if (count > 0)
            {
                TempData["empid"] = count + 1;
            }
            else
            {
                TempData["empid"] = 1;
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName,Gender,DOB,ContactNumber,Password,ConfirmPassword,Designation,SecurityQuestion1,SecurityQuestion2,SecurityQuestion3")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                context.Registrations.Add(registration);
                context.SaveChanges();
                ViewBag.Message = "Registration Successfull";
                return View("SuccessfullyUpdated");
            }

            return View(registration);
        }

       
    }
}
