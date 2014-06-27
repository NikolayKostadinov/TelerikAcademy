#define DEBUG
using System.Transactions;
using FileUpload.Data;
using FileUpload.Models.FileModels;
using FileUpload.Models.FileViewModels;
using FileUpload.Utility;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    [Authorize(Roles = "Upploader, Administrator")]
    public class FileUpploadController : Controller
    {
        private IUowData db;

        public FileUpploadController(IUowData db)
        {
            this.db = db;
        }
        // GET: FileUppload
        public ActionResult Index()
        {
            var files = db.FileDescriptions.All().ToList();

            return View(files);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAndPersist(IEnumerable<HttpPostedFileBase> upload)
        {
            StringBuilder messageBuilder = new StringBuilder();

            if (upload != null)
            {
                var fileBase = (HttpPostedFileWrapper)upload.FirstOrDefault();
                var fileDescription = new FileDescription();
                FileUploadHttpPostedFileWrapper file = new FileUploadHttpPostedFileWrapper(fileBase);
                var fileName = Path.GetFileName(file.FileName);
                var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                try
                {
                    using (var tran = new TransactionScope())
                    {
                        file.SaveAs(physicalPath);
                        fileDescription = file.ToFileDescription(User.Identity.GetUserId());
                        db.FileDescriptions.Add(fileDescription);
                        var upploadResult = FuleUploadUtility.ParseFile(physicalPath, fileDescription);

                        //foreach (var record in upploadResult)
                        //{
                        //    db.UploadResults.Add(record);
                        //}
                        db.UploadResults.BulkInsert(upploadResult);
                        db.SaveChanges();
                        tran.Complete();
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    messageBuilder.Append(ex.Message + "<br/>");
                }
                catch (System.IO.IOException ex)
                {
                    messageBuilder.Append(ex.Message + "<br/>");
                }
                catch (InvalidOperationException ex)
                {
#if DEBUG
                    messageBuilder.Append(ex.Message + "<br/>");
#endif
                    messageBuilder.Append("Файлът неможе да бъде качен!" + "<br/>");
                    if (System.IO.File.Exists(physicalPath))
                    {
                        try
                        {
                            System.IO.File.Delete(physicalPath);
                        }
                        catch (Exception e)
                        {
                            messageBuilder.Append(e.Message + "<br/>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    messageBuilder.Append("Файлът неможе да бъде качен!<br/>");
                    if (System.IO.File.Exists(physicalPath))
                    {
                        try
                        {
                            System.IO.File.Delete(physicalPath);
                        }
                        catch (Exception e)
                        {
                            messageBuilder.Append(e.Message + "<br/>");
                        }
                    }
                }

                if (messageBuilder.Length > 0)
                {
                    return Content(messageBuilder.ToString());
                }
                else
                {
                    return Json(new { status = 200, fileId = fileDescription.Id });
                }

            }

            return Content("Файлът неможе да бъде качен!");
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult GetUploadResults([DataSourceRequest]DataSourceRequest request, int fileId)
        {
            //for test only!!!!
            //fileId = 20;
            var results = db.UploadResults.All().Where(x => x.FileId == fileId).Select(UploadResultViewModel.ToUploadResultViewModel);
            return Json(results.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult GetUploadedFiles([DataSourceRequest]DataSourceRequest request)
        {
            var fileDescriptions = db.FileDescriptions.All().Select(FileDescriptionViewModel.ToFileDescriptionViewModel);
            return Json(fileDescriptions.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}