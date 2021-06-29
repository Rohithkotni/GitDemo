using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AirportManagementSystem.Models;

namespace AirportManagementSystem.Controllers
{
    
    public class HomeController : Controller
    {
       
        AirportManagementSystemContext context = new AirportManagementSystemContext();
        //AdminCredentials adminCrendials = new AdminCredentials();
        //Registration regis = new Registration();
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(AdminCredentials admin)
        {
            //var check = from a in context.AdminCredentials where a.UserName == admin.UserName select a;

            var validation = context.AdminCredentials.Where(a => a.AdminId.Equals(admin.AdminId) && a.Password.Equals(admin.Password)).FirstOrDefault();
            if (validation != null)
            {
                Session["user"] = admin.AdminId;
                return View("AdminLoginPage");
            }
            else
            {
                ViewBag.Message = "Invalid UserName Or Password";
                return View();

            }



        }

        [HttpGet]
        public ActionResult ManagerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManagerLogin(ManagerCredentials managerCredentials)
        {
            Registration registration = context.Registrations.FirstOrDefault(x => x.EmployeeId == managerCredentials.ManagerId);
            if(registration!=null)
            {
                var idValidation = ((registration.EmployeeId == managerCredentials.ManagerId) && (registration.Password == managerCredentials.Password));

                bool designaitonValidation = registration.Designation.StartsWith("Ma");

                var statusValidation = (registration.Active == true);



                if (idValidation)
                {
                    if (designaitonValidation)
                    {
                        if (statusValidation)
                        {
                            Session["user"] = managerCredentials.ManagerId;
                            return RedirectToAction("ManagerHomePage", "Manager");
                        }
                        else
                        {
                            ViewBag.Message = "You are not yet Approved by the Admin";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect UserName and Password";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Incorrect UserName and Password";
                    return View();
                }


            }
            else
            {
                ViewBag.Message = "Incorrect UserName and Password";
                return View();
            }


        }

        [HttpGet]
        public ActionResult PilotLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PilotLogin(PilotCredentials pilotCredentials)
         {
             Registration registration = context.Registrations.FirstOrDefault(x => x.EmployeeId == pilotCredentials.PilotId);
            if(registration!=null)
            {
                var idValidation = ((registration.EmployeeId == pilotCredentials.PilotId) && (registration.Password == pilotCredentials.Password));
                var designationValidation = registration.Designation.StartsWith("Pi");
                var statusValidation = (registration.Active == true);

                if (idValidation)
                {
                    if (designationValidation)
                    {
                        if (statusValidation)
                        {
                            Session["user"] = pilotCredentials.PilotId;
                            return RedirectToAction("PilotHomePage", "Pilot");
                        }
                        else
                        {
                            ViewBag.Message = "You are not yet Approved by the Admin";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect UserName Or Password";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Incorrect UserName Or Password";
                    return View();

                }

            }
            else
            {
                ViewBag.Message = "Incorrect UserName Or Password";
                return View();
            }
        }



        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.List = new List<string>() { "Manager", "Pilot" };
            return View();
        }

        

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        public ActionResult AdminLoginPage()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Help()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Help(Help help)
        {
            if(help!=null)
            {
                context.Help.Add(help);
                context.SaveChanges();
                ViewBag.Message = "Request sent Successfully";
                return View();
            }
            return View("Error");
        }

        public ActionResult ListOfIssues()
        {
            return View(context.Help.ToList());
        }

        public ActionResult SecurityQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SecurityQuestion(Registration registration)
        {
            Registration registrationCheck = context.Registrations.FirstOrDefault(r => r.EmployeeId == registration.EmployeeId);
            if(registration!=null)
            {
                var securityQuestionCheck1 = registrationCheck.SecurityQuestion1 == registration.SecurityQuestion1;
                var securityQuestionCheck2 = registrationCheck.SecurityQuestion2 == registration.SecurityQuestion2;
                var securityQuestionCheck3 = registrationCheck.SecurityQuestion3 == registration.SecurityQuestion3;

                if(securityQuestionCheck1 && securityQuestionCheck2 && securityQuestionCheck3)
                {
                    
                    return View("ResetPassword");
                }
                else
                {
                    ViewBag.Message = "Your Answers to Security Questions are Incorrect";
                    return View("SuccessfullyUpdated");
                }
            }
            else
            {
                ViewBag.Message = "Employee Id is InCorrect";
                return View("SuccessfullyUpdated");
            }
            
        }

        public ActionResult ResetPassword()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(Registration registration)
        {
            Registration registration1 = context.Registrations.Find(registration.EmployeeId);
            if(registration1!=null)
            {
                registration1.Password = registration.Password;
                registration1.ConfirmPassword = registration.ConfirmPassword;
                context.SaveChanges();
                ViewBag.Message = "Password Changed Successfully";
                return View("SuccessfullyUpdated");
            }
            return View("Error");
        }


        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            Session.Remove("user");
            return View();
        }
    }
}