using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoUIWrappersTest.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetDateTime(DateTime datetime)
        {
            var str = string.Format("{0:dd.MM.yyyy hh:mm:ss tt}", datetime);
            Debug.WriteLine(str);
            return Content(str);
        }
    }
}