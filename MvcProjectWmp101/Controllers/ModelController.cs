using MvcProjectWmp101.Models;
using MvcProjectWmp101.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        [HttpGet] // Burada ilk başta index'e yazdırdıklarımız önümüze geliyor.
        public ActionResult Index()
        {
            Kisi kisi = new Kisi();
            kisi.Ad = "Onur";
            kisi.Soyad = "Agici";
            kisi.Yas = 44;

            Adres adr = new Adres();
            adr.AdresTanimi = "Deneme Adresi";
            adr.Sehir = "İstanbul";

            indexViewModel mod = new indexViewModel();
            mod.KisiNesnesi = kisi;
            mod.AdresNesnesi = adr;

            return View(mod);
        }

        [HttpPost] // Ekranda değişiklik yapıp göndere bastıktan sonra sayfanın tekrar değişip gözümüze gelmesine post denir.Burada bu işlemi yapıyoruz.Bunu veritabanına kayıt edip oradan da çağırabilirdik.
        public ActionResult Index(indexViewModel model) //Kullanıcıdan gelenleri indexViewModelden model nesnesine yeni verileri atıyoruz.
        {
            return View(model);
        }
    }
}