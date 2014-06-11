using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Countries.Data.Models;
using Countries.Data.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace KendoUIWrappersTest.Controllers
{
    public class WorldController : Controller
    {
        public WorldController()
        {
            this.Data = new WorldContext();
        }

        public WorldContext Data { get; set; }

        // GET: World
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCountries([DataSourceRequest]DataSourceRequest request) 
        {
            var countires = this.Data.Countries.Include("Cities").Include("CountryLanguages").Select(CountryViewModel.ToCountryViewModel);

            return Json(countires.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}