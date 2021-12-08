using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProjectWmp101.Controllers
{
    public class AddressesController : Controller
    {
        // GET: Addresses
        public ActionResult NewAddress()
        {
            DatabaseContext db = new DatabaseContext();

            List<SelectListItem> personsList = (from s in db.Persons.ToList()
                                                select new SelectListItem()
                                                {
                                                    Text = s.Name + " " + s.SurName,
                                                    Value = s.Id.ToString()
                                                }).ToList();


            // Bu yapı Linq olmadan yapılmış halidir.
            ////Heap                                                              Stack
            ////InstantName (Aşağıdaki persons) tutuluyor.                 refno 101{0-name1,1-name2}   Persons tablosu içerisindeki bilgiler tutuluyor. 
            //List<Persons> persons = db.Persons.ToList();
            //List<SelectListItem> personsList = new List<SelectListItem>();
            //foreach (Persons person in persons)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = person.Name + " " + person.SurName;
            //    item.Value = person.Id.ToString();
            //    personsList.Add(item);
            //}
            TempData["persons"] = personsList;
            ViewBag.persons = personsList; // ViewBag ve Viewdata bizim veritabanına gönderebildiğimiz bilgileri taşıyoruz.ViewBag burada çalışıyor ve ömrü btiyor.Bu yüzden buraya daha uzun ömürlü bir takviye gönderiyoruz.TempData view e veri taşıyamıyor.Bu yüzden.Aşağıda viewbag.persons=TempData["persons"] yazıyoruz.

            return View();
        }
        [HttpPost]
        public ActionResult NewAddress(Addresses address)
        {
            DatabaseContext db = new DatabaseContext(); //db oluşturduk.

            Persons person = db.Persons.Where(x => x.Id == address.Persons.Id).FirstOrDefault(); //eğer böyle bir kayıt varsa ilk kayıtı getir yoksa default getir.
            if (person != null)
            {
                address.Persons = person;
                db.Addresses.Add(address);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Address enrollment completed successfully.";
                    ViewBag.Status = "success";

                }
                else
                {
                    ViewBag.Result = "Address enrollment failure";
                    ViewBag.Status = "danger";
                }

            }
            ModelState.Clear();
            ViewBag.persons = TempData["persons"];
            return View();
        }
        public ActionResult Update(int? aid)
        {
            Addresses adr = null;
            if (aid != null)
            {
                DatabaseContext db = new DatabaseContext();
                List<SelectListItem> personsList = (from s in db.Persons.ToList()
                                                    select new SelectListItem()
                                                    {
                                                        Text = s.Name + " " + s.SurName,
                                                        Value = s.Id.ToString()
                                                    }).ToList();


                adr = db.Addresses.FirstOrDefault(x => x.Id == aid);
                personsList.Find(x => x.Value == adr.Persons.Id.ToString()).Selected = true;
                TempData["persons"] = personsList;
                ViewBag.persons = personsList;
            }

            return View(adr);
        }

        [HttpPost]
        public ActionResult Update(Addresses model,int? aid)
        {
           
                DatabaseContext db = new DatabaseContext();
            Persons person = db.Persons.FirstOrDefault(x => x.Id == model.Persons.Id);
            Addresses address = db.Addresses.FirstOrDefault(s => s.Id == aid);

            if (person!=null)
            {
                address.Persons = person;
                address.Description = model.Description;
                address.City = model.City;

                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Address updated successfully.";
                    ViewBag.Status = "success";

                }
                else
                {
                    ViewBag.Result = "Address updated failure";
                    ViewBag.Status = "danger";
                }
            }
                ViewBag.persons = TempData["persons"];
           

            return View();
        }
    }
}