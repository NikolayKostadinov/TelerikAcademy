using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcUserAdministration.Controllers
{
    [Authorize(Roles = "Upploader, Administrator")]
    public class FileUpploadController : Controller
    {
        // GET: FileUppload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveAndPersist(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                foreach (var file in upload)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    file.SaveAs(physicalPath);
                }
            }

            return Content("");
        }

        public ActionResult RemoveAndPersist(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"
            if (fileNames != null)
            {
                //if (fileNames != null)
                //{
                //    foreach (var file in fileNames)
                //    {
                //        var fileName = Path.GetFileName(file);
                //        var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                //        file.SaveAs(physicalPath);
                //    }
                //}

                return Content("");
            }

            // Return an empty string to signify success
            return Content("");
        }
    }
}