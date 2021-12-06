using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcProjectWmp101.Controllers
{
    public class StudentController:Controller
    {
        public ActionResult Index1()
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            List<Students> students = db.Students.ToList();
          
            return View(students);
        }
    }
}