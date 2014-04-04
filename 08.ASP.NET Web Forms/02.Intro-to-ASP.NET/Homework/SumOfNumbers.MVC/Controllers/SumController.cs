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
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Sum()
        {
            return View();
        }

        //
        // POST: /Sum/Calculate
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Sum(int firstNumber, int secondNumber)
        {
            var sumModel = new SumModel()
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber
            };
            this.ViewBag.Result = sumModel.Result;
            return View("Sum");
        }
    }
}