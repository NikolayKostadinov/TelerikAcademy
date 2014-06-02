using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculator.Domain;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            IUnit unit = new Unit() { Name = Measure.MegaByte, Value = 1 };

            MeasuresCalculator m = new MeasuresCalculator(unit, KiloMultiplier.k2);
            
            ViewBag.Kilo = GetKilo();
            ViewBag.Quantity = 1;
            
            return View(m);
        }

        private static IEnumerable<SelectListItem> GetKilo(KiloMultiplier selected = KiloMultiplier.k2)
        {
            IEnumerable<SelectListItem> kilo = new List<SelectListItem>
            {
                new SelectListItem(){Text=((int)KiloMultiplier.k2).ToString(), Value = ((int)KiloMultiplier.k2).ToString()},
                new SelectListItem(){Text=((int)KiloMultiplier.k1).ToString(), Value = ((int)KiloMultiplier.k1).ToString()}
            };

            kilo.First(x => { return x.Value == ((int)selected).ToString(); }).Selected = true;
            return kilo;
        }


        [HttpPost]
        public ActionResult Index(int Quantity, int Type, int Kilo)
        {
            IUnit unit = new Unit() { Name = (Measure)Type, Value = (int)Quantity };

            MeasuresCalculator m = new MeasuresCalculator(unit, (KiloMultiplier)Kilo);

            //IEnumerable<SelectListItem> kilo = new List<SelectListItem>
            //{
            //    new SelectListItem(){Text=((int)KiloMultiplier.k2).ToString(), Value = ((int)KiloMultiplier.k2).ToString(),Selected=true},
            //    new SelectListItem(){Text=((int)KiloMultiplier.k1).ToString(), Value = ((int)KiloMultiplier.k1).ToString()}
            //};

            ViewBag.Quantity = Quantity;
            ViewBag.Kilo = GetKilo((KiloMultiplier)Kilo);

            return View(m);
        }
    }
}