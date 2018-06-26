namespace CalculatorMvc.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class MathController : Controller
    {
        public ActionResult Index(double? firstNumber, double? secondNumber, string calc, double? result)
        {
            if (firstNumber.HasValue && secondNumber.HasValue)
            {
                result = 0;
                if (calc == "+")
                {
                    result = firstNumber.Value + secondNumber.Value;
                }
                switch (calc)
                {
                    case "+":
                        result = firstNumber.Value + secondNumber.Value;
                        break;

                    case "-":
                        result = firstNumber.Value - secondNumber.Value;
                        break;

                    case "*":
                        result = firstNumber.Value * secondNumber.Value;
                        break;

                    case "/":
                        result = firstNumber.Value / secondNumber.Value;
                        break;

                    default:
                        break;
                }

                this.ViewBag.firstNumber = firstNumber.ToString();
                this.ViewBag.secondNumber = secondNumber.ToString();
                this.ViewBag.calc = calc.ToString();
                this.ViewBag.result = result.ToString();

                return this.View();
            }

            this.ViewBag.result = this.ViewBag.firstNumber = this.ViewBag.secondNumber = 0;
            return this.View();
        }
    }
}