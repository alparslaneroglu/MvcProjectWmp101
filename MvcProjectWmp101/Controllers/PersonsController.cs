using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult NewPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPerson(Persons persons) // persons burada gelen bilgidir.
        {
            DatabaseContext db = new DatabaseContext();
            db.Persons.Add(persons);

            int result = db.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Person enrollment completed successfully."; // ViewBag ekrana küçük verileri 1 seferlik ömrü olan gösteriyor.
                ViewBag.Status = "success"; // Result status isimlerini kendimiz belirledik.Herhangi başka bir şeyde yazılabilir.

            }
            else
            {
                ViewBag.Result = "Person enrollment failure";
                ViewBag.Status = "danger";
            }
            ModelState.Clear(); // Submit sonrası textboxların içerisini boşaltıyor.
            return View();  
        }


    }
}