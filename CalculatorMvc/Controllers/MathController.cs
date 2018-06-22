namespace CalculatorMvc.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class MathController : Controller
    {
        public ActionResult Index(double? firstNumber, double? secondNumber, string calc)
        {
            if (firstNumber.HasValue && secondNumber.HasValue)
            {
                double result = 0;
                switch (calc)
                {
                    case "Add":
                        result = firstNumber.Value + secondNumber.Value;
                        break;

                    case "Min":
                        result = firstNumber.Value - secondNumber.Value;
                        break;

                    case "Mul":
                        result = firstNumber.Value * secondNumber.Value;
                        break;

                    case "Div":
                        result = firstNumber.Value / secondNumber.Value;
                        break;

                    default:
                        break;
                }

                this.ViewBag.firstNumber = firstNumber.ToString();
                this.ViewBag.secondNumber = secondNumber.ToString();
                this.ViewBag.Result = result.ToString();

                return this.View();
            }

           // this.ViewBag.Result = this.ViewBag.firstNumber = this.ViewBag.secondNumber = 0;
            return this.View();
        }
    }
}