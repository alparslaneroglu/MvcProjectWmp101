using MvcProjectWmp101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.ViewModel
{
    public class PerAddViewModel
    {
        //2 tane classı liste halinde view modelin içerisinde koyduk
        public List<Persons> Persons { get; set; }
        public List<Addresses> Addresses { get; set; }
    }
}