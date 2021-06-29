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
    
    public class AdminController : Controller
    {
        private AirportManagementSystemContext db = new AirportManagementSystemContext();

        // GET: AdminPlane
        public ActionResult Index()
        {
            return View(db.Planes.ToList());
        }

        // GET: AdminPlane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Planes.Find(id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }

        // GET: AdminPlane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPlane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaneId,ModelNumber,PurchaseDate,LastServicedDate,PlaneStatus")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                db.Planes.Add(plane);
                db.SaveChanges();
                ViewBag.Message = "Your details are Submitted Successfully";
                return View("SuccessfullyUpdated");
            }

            return View(plane);
        }

        [HttpGet]
        public ActionResult CreateSchedule()
        {
            var pilotlist=(from i in db.Registrations where i.Designation == "Pilot" select i).ToList();
            ViewBag.PilotList = new SelectList(pilotlist, "EmployeeId", "FirstName");
            ViewBag.PlaneList = new SelectList(db.Planes, "PlaneId", "PlaneId");
            return View();
        }

        [HttpPost]
        public ActionResult CreateSchedule(Schedule schedule)
        {
            db.Schedules.Add(schedule);
            db.SaveChanges();
            ViewBag.Message = "Scheduled Successfully";
            return View("SuccessfulMessage");
        }


       
        public ActionResult EditSchedule(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            var pilotlist = (from i in db.Registrations where i.Designation == "Pilot" select i).ToList();
            ViewBag.PilotList = new SelectList(pilotlist, "EmployeeId", "FirstName");
            ViewBag.PlaneList = new SelectList(db.Planes, "PlaneId", "PlaneId");
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }


        // POST: AdminPlane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSchedule([Bind(Include = "ScheduleDate,ScheduleTime,AllocatedPlaneId,AllocatedPilotId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
               var sch= db.Schedules.FirstOrDefault(s => s.AllocatedPlaneId == schedule.AllocatedPlaneId);
                sch.ScheduleDate = schedule.ScheduleDate;
                sch.ScheduleTime = sch.ScheduleTime;
                db.SaveChanges();
                ViewBag.Message = "You details submitted Successfully";
                return View("SuccessfullyUpdated");
            }
            return View(schedule);
            
        }

        public ActionResult ListOfSchedule()
        {
           
            return View(db.Schedules.ToList());
        }
        
        [HttpGet]
        public ActionResult CreateHangars()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHangars(Hangar hangar)
        {
          
                  
                    db.Hangers.Add(hangar);
                    hangar.Status = false;
                    db.SaveChanges();
                    ViewBag.Message = "Plane allocated to Hangar Successfully";
                    return View("SuccessfulMessage");
               
           
        }


        public ActionResult ListOfHangar()
        {
            
            return View(db.Hangers.ToList());
        }

        //public ActionResult UpdateHangar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Hangar hangar = db.Hangers.Find(id);
        //    if (hangar == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(hangar);
        //}

        //[HttpPost]
        //public ActionResult UpdateHangar(Hangar hangar)
        //{
        //    Hangar hangar1 = db.Hangers.Find(hangar.HangarId);
        //    if(hangar1!=null)
        //    {
        //        hangar1.PlaneId = hangar.PlaneId;
        //        hangar1.Status = hangar.Status;
        //        db.SaveChanges();
        //        ViewBag.Message="Hangar Details Updated Successfully";
        //        return View("SuccessfulMessage");
        //    }
        //    return View("Error");
        //}

        public ActionResult HangarDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangar hangar = db.Hangers.FirstOrDefault(h=>h.HangarId == id);
            if (hangar == null)
            {
                return HttpNotFound();
            }
            return View(hangar);
        }



       


        public ActionResult CreateWayPoint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWayPoint(Waypoint wayPoint)
        {
            if (wayPoint != null)
            {
                db.Waypoints.Add(wayPoint);
                db.SaveChanges();
                ViewBag.Message = "WayPoint Created Successfully";
                return View("SuccessfullyUpdated");
            }
            return View("Error");
        }






        public ActionResult ListOfWayPoint()
        {
           
            return View(db.Waypoints.ToList());
        }

        public ActionResult UpdateWayPoint(int? id)
        {
            if(id!=null)
            {
                Waypoint wayPoint = db.Waypoints.Find(id);
                return View(wayPoint);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult UpdateWayPoint(Waypoint wayPoint)
        {
            Waypoint wayPointDB = db.Waypoints.FirstOrDefault(w=>w.ID == wayPoint.ID);
            
                              
                wayPointDB.Altitude = wayPoint.Altitude;
                wayPointDB.Latitude = wayPoint.Latitude;
                wayPointDB.Longitude = wayPoint.Longitude;
                wayPointDB.Speed = wayPoint.Speed;
                db.SaveChanges();
                ViewBag.Message = "Way Point Details Updated Successfully";
                return View("SuccessfulMessage");
            
        }

        public ActionResult WayPointDetails(int? id)
        {
            if(id!=null)
            {
                Waypoint wayPoint = db.Waypoints.FirstOrDefault(w=>w.WaypointId == id);
                return View(wayPoint);
            }
            return View("Error");
        }

        public ActionResult DeleteWayPoint(int? id)
        {
            if(id!=null)
            {
                Waypoint wayPoint = db.Waypoints.FirstOrDefault(w => w.WaypointId == id);
                return View(wayPoint);
            }

            return View("Error");
        }
        [HttpPost, ActionName("DeleteWayPoint")]
        public ActionResult ConfirmDeleteWayPoint(int? id)
        {
            if(id!=null)
            {
                Waypoint wayPoint = db.Waypoints.Find(id);
                if(wayPoint!=null)
                {
                    db.Waypoints.Remove(wayPoint);
                    db.SaveChanges();
                    ViewBag.Message = "WayPoint Deleted Successfully";
                    return View("SuccessfulMessage");
                }
                return View("Error");
            }
            return View("Error");

        }

        


        // GET: AdminPlane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Planes.Find(id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }


        // POST: AdminPlane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaneId,ModelNumber,PurchaseDate,LastServicedDate,PlaneStatus")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(plane).State = EntityState.Modified;
                var validation = db.Planes.FirstOrDefault(p => p.PlaneId == plane.PlaneId);
                validation.LastServicedDate = plane.LastServicedDate;
                validation.PlaneStatus = plane.PlaneStatus;
                db.SaveChanges();
                ViewBag.Message = "You details submitted Successfully";
                return View("SuccessfullyUpdated");
                //return RedirectToAction("Index");
            }
            return View(plane);
        }

        // GET: AdminPlane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Planes.FirstOrDefault(p=>p.PlaneId == id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }

        // POST: AdminPlane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Plane plane = db.Planes.Find(id);
            db.Planes.Remove(plane);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Reports()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reports(string report)
        {
            string answer = Request["report"];
            if(answer == "ListOfSchedule")
            {
                var result = db.Schedules.ToList();
                return View("ScheduleList",result);
            }
            else if(answer == "ListOfHangar")
            {
                var result = db.Hangers.ToList();
                return View("HangerList",result);
            }
            else if(answer == "ListOfPlane")
            {
                var result = db.Planes.ToList();
                return View("PlanesList",result);
            }
            else
            {
                return View();
            }
           
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