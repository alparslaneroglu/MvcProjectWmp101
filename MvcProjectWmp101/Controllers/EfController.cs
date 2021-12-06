﻿using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class EfController : Controller
    {
        // GET: Ef
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            List<Persons> persons = db.Persons.ToList();
            //select *from persons => sql karşılığı.
            return View(persons);
        }
    }
}