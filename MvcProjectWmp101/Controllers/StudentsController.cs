using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult NewStudent()
        {
            return View();
        }

        [HttpPost]

        public ActionResult NewStudent(Students students)
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            db.Students.Add(students);

            int result = db.SaveChanges();

            if (result>0)
            {
                ViewBag.Result = " Kayıt Başarılı";
                ViewBag.Status = "success";

            }
            else
            {
                ViewBag.Result = "Neyi Başaramadın ?";
                ViewBag.Status = "danger";
            }
            ModelState.Clear();
            return View();
        }
    }
}