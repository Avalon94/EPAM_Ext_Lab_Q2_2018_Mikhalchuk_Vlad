using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Operations : Controller
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int result { get; set; }

        public bool add { get; set; }
        public bool sub { get; set; }
        public bool mult { get; set; }
        public bool div { get; set; }
    }
}