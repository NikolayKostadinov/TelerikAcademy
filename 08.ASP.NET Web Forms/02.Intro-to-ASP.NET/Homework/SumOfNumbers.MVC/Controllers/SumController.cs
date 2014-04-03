using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SumOfNumbers.MVC.Models;

namespace SumOfNumbers.MVC.Controllers
{
    public class SumController : Controller
    {
        //
        // POST: /Sum/Calculate
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Calculate(int firstNumber, int secondNumber)
        {
            var sunModel = new SumModel()
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber
            };

            return View("Sum");
        }
    }
}