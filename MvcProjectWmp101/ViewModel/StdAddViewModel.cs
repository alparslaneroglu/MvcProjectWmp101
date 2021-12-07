using MvcProjectWmp101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.ViewModel
{
    public class StdAddViewModel
    {
        public List<Students> Students { get; set; }

        public List<Classes> Classes { get; set; }
    }
}