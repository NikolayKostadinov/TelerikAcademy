using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models.FileModels;

namespace FileUpload.Utility
{
    public static class HttpPostedFileWrapperExtention
    {
        public static FileDescription ToFileDescription(this FileUploadHttpPostedFileWrapper postedFile, string UserId)
        {
            var fileDescription = new FileDescription();
            var fileSize = (int)Math.Ceiling((decimal)(postedFile.ContentLength / 1024));
            fileSize = fileSize > 0 ? fileSize : 1;
            fileDescription.FileName = postedFile.FileName;
            fileDescription.Size = fileSize;
            fileDescription.UploadTime = DateTime.Now;
            fileDescription.UserId = UserId;
            return fileDescription;
        }
    }
}
