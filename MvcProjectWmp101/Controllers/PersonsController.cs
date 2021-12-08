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
        public ActionResult Update(int? pid) //int normalde null gelemez fakat sonuna ? koyarak null bırakılabilir olacağını söylüyoruz.
        {
            Persons per = null; // Bunu içeridede null yapmadan direkt olarak Person per diye tanımlayabilirdik fakat bu seferde else yapısııda eklememiz gerekir.
            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                per = db.Persons.FirstOrDefault(x => x.Id == pid);

            }

            return View(per);
        }
        [HttpPost] //,ActionName("Update") Burayı update gibi kullanabilirsin.Yukarıdaki update 'in postu gibi kullan diyoruz.Bu sayde 2 farklı metodu tek bir metodun çatısı altında toplayabiliyoruz.
        public ActionResult Update(Persons model, int? pid)
        {
            DatabaseContext db = new DatabaseContext();
            Persons persons = db.Persons.FirstOrDefault(x => x.Id == pid);
            if (persons != null)
            {
                persons.Name = model.Name;
                persons.SurName = model.SurName;
                persons.Age = model.Age;
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Person updated successfully.";
                    ViewBag.Status = "success";

                }
                else
                {
                    ViewBag.Result = "Person updated failure";
                    ViewBag.Status = "danger";
                }

            }


            return View();
        }

        public ActionResult Delete(int? pid)
        {

            Persons per = null;
            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                per = db.Persons.Find(pid);
            }
            return View(per);
        }

        [HttpPost,ActionName ("Delete")]
         public ActionResult DeleteOk(int? pid,int? aid)
        {

            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Persons per = db.Persons.Find(pid);
                List<Addresses> adr = (from s in db.Addresses where s.Persons.Id == pid select s).ToList();
                //var adr = db.Addresses.Where(x => x.Persons.Id == per.Id).ToList();
                db.Addresses.RemoveRange(adr);
                db.Persons.Remove(per);

                db.SaveChanges();

            }
            return RedirectToAction("Index","Ef");
        }



    }
}