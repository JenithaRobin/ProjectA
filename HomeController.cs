using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CMS.CDAL;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ULogin(Login lo)
        {
            if (ModelState.IsValid)
            {
                ClinicDAL obj = new ClinicDAL();
                int result = obj.Loginuser(lo);
                if (result == 1)
                {
                    TempData["msg"] = "<script>alert('Successfully LoggedIn');</script>";

                    return RedirectToAction("MainMenu");
                }
                else
                    return View("Index");


            }
            else
            {
                return View("Index");
            }
            
        }
        [Route("Mainmenu")]
        public IActionResult MainMenu()
        {
            return View();
        }
        [Route("doctor")]
        public IActionResult ADDdoctor()
        {
            return View();
        }
        public IActionResult DoctorVaithi(Doctor d)
        {
            ClinicDAL doc = new ClinicDAL();
            int result = doc.doctor1(d);
            if (result == 1)
            {
                TempData["msg"] = "<script>alert('Doctor Added Successfully');</script>";

                return RedirectToAction("MainMenu");
            }
            else
                return View("Index");
        }
        public IActionResult ADDpatient()
        {
            return View();
        }
        public IActionResult Patientp(Patient p)
        {
            ClinicDAL pat = new ClinicDAL();
            int result = pat.patient1(p);
            if (result == 1)
            {
                TempData["msg"] = "<script>alert('Patient Added Successfully');</script>";
                return RedirectToAction("MainMenu");
            }
                
            else
                return View("Index");
        }
        public IActionResult Appointment()
        {
            
            return View();
        }
        public IActionResult AppointmentSchedule(Schedule s)
        {
            ClinicDAL apo = new ClinicDAL();
            int result = apo.AppointSch(s);
            if (result == 1)
            {
                TempData["msg"] = "<script>alert('Appointment Fixed Successfully');</script>";
                return RedirectToAction("MainMenu");
            }
            else
                return View("AppoSch");
        }
        //public IActionResult ScheduleApmt()
        //{
        //    return View();
        //}
        //public IActionResult Sched(Schedules s)
        //{
        //    ClinicDAL obj3 = new ClinicDAL();
        //    int result = obj3.Sch(s);
        //    if (result == 1)
        //        return RedirectToAction("MainMenu");
        //    else
        //        return View("ScheduleApmt");
        //}
        
        public IActionResult Display()
        {
            ClinicDAL SDAL = new ClinicDAL();
            List<Schedule> ScheduleList = new List<Schedule>();
            ScheduleList = SDAL.Scheduledelete();
            return View(ScheduleList);
        }
        public IActionResult Cancel(int id)
        {
            ClinicDAL can = new ClinicDAL();
            int result = can.CancelAppointSch(id);
            if (result == 1)
            {
                TempData["msg"] = "<script>alert('Appointment Cancelled');</script>";

                return RedirectToAction("MainMenu");
            }
            else
                return View("MainMenu");

            
        }
        

       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
