using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult total(double x, double y, string calc)
        {
            double total = 0;
            switch(calc)
            {
                case "Add":
                    total = x + y;
                    break;

                case "Min":
                    total = x - y;
                    break;

                case "Mul":
                    total = x * y;
                    break;

                case "Div":
                    total = x / y;
                    break;

                default:
                    break;
            }
            return Content("Результат: " + total);
        }
    }
}