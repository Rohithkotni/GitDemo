using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AirportManagementSystem.Models;

namespace AirportManagementSystem.Controllers
{
    public class PilotController : Controller
    {
        AirportManagementSystemContext db = new AirportManagementSystemContext();
        // GET: Pilot
        public ActionResult Index()
        {
            return View();
        }

        // Home Page Of Pilot
        public ActionResult PilotHomePage()
        {

            return View("PilotHomePage");
        }


        // Create the FlightPlan
        [HttpGet]
        public ActionResult FlightPlan()
        {
           
          ViewBag.WayPointList = new SelectList(db.Waypoints, "ID", "ID");
            ViewBag.PlaneList = new SelectList(db.Planes, "PlaneId", "PlaneId");
            return View();
        }

        [HttpPost]
        public ActionResult FlightPlan(FlightPlan flightPlan)
        {
            if(flightPlan != null)
            {
                db.FlightPlans.Add(flightPlan);
                db.SaveChanges();
                ViewBag.Message = "Your details are submitted Successfully";
                return View("SuccessfullyUpdated");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult ScheduledPlanes()
        {
           
            return View(from s in db.Schedules orderby s.ScheduleDate orderby s.ScheduleTime descending select s);
        }

        [HttpPost]
        public ActionResult ScheduledPlanes(Schedule schedule)
        {
            return View();
        }


        // For Creation on UI(PreChecklist)
        [HttpGet]
        public ActionResult PreCheckList()
        {
            ViewBag.PlaneList = new SelectList(db.Planes, "PlaneId", "PlaneId");
            return View();
        }


        // For Validation of the PrechecklistEdit

        [HttpPost]
        public ActionResult PreCheckList(PreCheckList preCheckList)
        {
            
            var firstCheck = db.Planes.FirstOrDefault(p => p.PlaneId == preCheckList.YourPlaneId);
            
            if(firstCheck != null)
            {
                if (preCheckList.Power.StartsWith("Ve") && preCheckList.BatteryVoltage.StartsWith("Ve") && preCheckList.BatteryCables.StartsWith("Se")
                && preCheckList.HomeAltitude.StartsWith("Ch") && preCheckList.FlightPlan.StartsWith("As") && preCheckList.GPS.StartsWith("Co")
                    && preCheckList.Antenna.StartsWith("Co") && preCheckList.Speed.StartsWith("Ch"))
                {
                    firstCheck.PlaneStatus = true;
                    db.PreCheckLists.Add(preCheckList);
                    db.SaveChanges();
                    ViewBag.Message = "Pre-CheckList of Plane Checked Successfully";
                    return View("SuccessfullyUpdated");
                }
                else
                {
                    firstCheck.PlaneStatus = false;
                    db.PreCheckLists.Add(preCheckList);
                    db.SaveChanges();
                    ViewBag.Message = "Pre-CheckList of Plane Partially Completed";
                    return View("SuccessfullyUpdated");
                }
            }
            return View("Error");
        }

        public ActionResult ListOfPreCheckList()
        {
            
            return View(db.PreCheckLists.ToList());
        }

        [HttpGet]
        public ActionResult PostCheckList()
        {
            ViewBag.PlaneList = new SelectList(db.Planes, "PlaneId", "PlaneId");
            return View();
        }


        // For Validation of the PrechecklistEdit

        [HttpPost]
        public ActionResult PostCheckList(PostCheckList postCheckList)
        {
            var firstCheck = db.Planes.FirstOrDefault(p => p.PlaneId == postCheckList.YourPlaneId);

            if (firstCheck != null)
            {
                if (postCheckList.Transponder.StartsWith("Ve") && postCheckList.WingFlaps.StartsWith("Ch") && postCheckList.CarbHeat.StartsWith("Se")
               && postCheckList.Lights.StartsWith("On") && postCheckList.Trim.StartsWith("Ve") && postCheckList.Mixture
                .StartsWith("Ch"))
                {
                    firstCheck.PlaneStatus = true;
                    db.PostCheckLists.Add(postCheckList);
                    db.SaveChanges();
                    ViewBag.Message = "Post-CheckList of Plane Checked Successfully";
                    return View("SuccessfullyUpdated");
                }
                else
                {
                    firstCheck.PlaneStatus =false;
                    db.PostCheckLists.Add(postCheckList);
                    db.SaveChanges();
                    ViewBag.Message = "Post-CheckList of Plane Partially Completed";
                    
                    return View("SuccessfullyUpdated");

                }
            }
            return View("Error");
        }

        public ActionResult ListOfPostCheckList()
        {
            
            return View(db.PostCheckLists.ToList());
        }

        public ActionResult ListOfFlightPlan()
        {
            return View(db.FlightPlans.ToList());
        }

        public ActionResult UpdateFlight()
        {
            return View();
        }

        public ActionResult UpdateFlightPlan(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightPlan flightPlan = db.FlightPlans.Find(id);
            if (flightPlan == null)
            {
                return HttpNotFound();
            }
            return View(flightPlan);
        }
        [HttpPost]
        public ActionResult UpdateFlightPlan(FlightPlan flightPlan)
        {
            FlightPlan flightPlanCheck = db.FlightPlans.Find(flightPlan.FlightPlanId);
            if(flightPlan != null)
            {
                flightPlanCheck.DepartureLocation = flightPlan.DepartureLocation;
                flightPlanCheck.EDA = flightPlan.EDA;
                flightPlanCheck.ETA = flightPlan.ETA;
                flightPlanCheck.AlternateAirports = flightPlan.AlternateAirports;
                db.SaveChanges();
                ViewBag.Message = "Flight Plan Details Successfully Updated";
                return View("SuccessfullyUpdated");
            }
            return View("Error");
        }


        public ActionResult FlightPlanDetails(int? id)
        {
            if (id != null)
            {
                FlightPlan flightPlan = db.FlightPlans.Find(id);
                return View(flightPlan);
            }
            else
            {
                return View("Error");
            }
        }
            


        public ActionResult DeleteFlightPlan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightPlan flightPlan = db.FlightPlans.Find(id);
            if (flightPlan == null)
            {
                return HttpNotFound();
            }
            return View(flightPlan);
        }

        // POST: AdminPlane/Delete/5
        [HttpPost, ActionName("DeleteFlightPlan")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFlightPlanConfirmed(int? id)
        {
            FlightPlan flightPlan = db.FlightPlans.Find(id);
            db.FlightPlans.Remove(flightPlan);
            db.SaveChanges();
            return RedirectToAction("PilotHomePage");
        }

       


        public ActionResult ListOfWayPoint()
        {

            return View(db.Waypoints.ToList());
        }

        public ActionResult WayPointDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waypoint wayPoint = db.Waypoints.FirstOrDefault(w=>w.WaypointId == id);
            if (wayPoint == null)
            {
                return HttpNotFound();
            }
            return View(wayPoint);
        }

        public ActionResult ListOfHangar()
        {

            return View(db.Hangers.ToList());
        }

        public ActionResult ScheduleButtons()
        {
            return View();
        }

        public ActionResult DailySchedule()
        {
            var dailySchedule = (from result in db.Schedules where result.ScheduleDate == DateTime.Now select result).ToList();
            return View(dailySchedule);
        }

        public ActionResult WeeklySchedule()
        {
           
            DateTime date = DateTime.Today.AddDays(6);

            var weeklySchedule = (from result in db.Schedules where date > DateTime.Now select result).ToList();
            return View(weeklySchedule);
        }

        public ActionResult MonthlySchedule()
        {
            DateTime date = DateTime.Today.AddDays(29);
            var monthlySchedule = (from result in db.Schedules where date > DateTime.Now select result).ToList();

            return View(monthlySchedule);
        }


        public ActionResult ListOfIssues()
        {
            return View(db.Help.ToList());
        }

        
    }
}