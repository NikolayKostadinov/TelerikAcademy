using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUpload.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace FileUpload.Controllers
{
    [Authorize(Roles="Administrator")]
    public class TraceLogController : Controller
    {
        private IUowData db;

        public TraceLogController(IUowData db)
        {
            this.db = db;
        }
        // GET: TraceLog
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetTraseLog([DataSourceRequest]DataSourceRequest request,
            DateTime begining,
            DateTime ending)
        {
            var traceLog = db.TraceLogMessages.All().Where(x => x.TimeStamp >= begining && x.TimeStamp <= ending);
            return Json(traceLog.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}