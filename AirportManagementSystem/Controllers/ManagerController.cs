using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportManagementSystem.Models;

namespace AirportManagementSystem.Controllers
{
    public class ManagerController : Controller
    {
        AirportManagementSystemContext db = new AirportManagementSystemContext();
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManagerHomePage()
        {
            return View("ManagerHomePage");
        }

        public ActionResult ListOfHangar()
        {

            return View(db.Hangers.ToList());
        }

        public ActionResult UpdateHangar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangar hangar = db.Hangers.Find(id);
            if (hangar == null)
            {
                return HttpNotFound();
            }
            return View(hangar);
        }

        [HttpPost]
        public ActionResult UpdateHangar(Hangar hangar)
        {
            Hangar hangar1 = db.Hangers.Find(hangar.ID);
            if (hangar1 != null)
            {
                hangar1.PlaneId = hangar.PlaneId;
                hangar1.Status = hangar.Status;
                db.SaveChanges();
                ViewBag.Message = "Hangar Details Updated Successfully";
                return View("SuccessfullyUpdated");
            }
            return View("Error");
        }

        public ActionResult HangarDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangar hangar = db.Hangers.Find(id);
            if (hangar == null)
            {
                return HttpNotFound();
            }
            return View(hangar);
        }

        public ActionResult ListOfIssues()
        {
           
            return View(db.Help.ToList());
        }

        public ActionResult ResolveIssue(int? id)
        {
            if(id!=null)
            {
                Help help = db.Help.Find(id);
                return View(help);
            }
            return View("Error");

        }
        [HttpPost]
        public ActionResult ResolveIssue(Help help)
        {
            if(help!=null)
            {
                Help helpCheck = db.Help.Find(help.ID);
                if(helpCheck!=null)
                {
                    helpCheck.Answer = help.Answer;
                    db.SaveChanges();
                    ViewBag.Message = "Issue Resolved Successfully";
                    return View("SuccessfullyUpdated");
                }
                return View("Error");

            }
            return View("Error");
        }

        public ActionResult IssueDetails(int? id)
        {
            if(id!=null)
            {
                Help help = db.Help.Find(id);
                return View(help);
            }

            return View("Error");
        }

        public ActionResult ListOfPreCheckList()
        {
            return View(db.PreCheckLists.ToList());
        }
        public ActionResult ListOfPostCheckList()
        {
            return View(db.PostCheckLists.ToList());
        }

       
    }
}