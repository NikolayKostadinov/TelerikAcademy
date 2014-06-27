using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAndPersist(IEnumerable<HttpPostedFileBase> upload)
        {
            StringBuilder messageBuilder = new StringBuilder();

            if (upload != null)
            {
                
                foreach (var file in upload)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                    if (!System.IO.File.Exists(physicalPath))
                    {
                        file.SaveAs(physicalPath);
                    }
                    else 
                    {
                        messageBuilder.Append("File \"" + file.FileName + "\" allready exists!<br />");
                    }
                }
            }

            if (messageBuilder.Length > 0)
            {
                return Content(messageBuilder.ToString());
            }
            else 
            {
                return Content("");
            }
        }
    }
}