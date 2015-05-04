//#define DEBUG
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileUpload.Models;
using FileUpload.Models.FileModels;

namespace FileUpload.Utility
{
    public class FuleUploadUtility
    {
        /// <summary>
        /// Sends file to cache for parsing
        /// </summary>
        /// <param name="fileName">Destination file name</param>
        /// <param name="fileDescription">Original POCO description of file</param>
       
        public static ICollection<UploadResult> ParseFile(string fileName, FileDescription fileDescription)
        {
            var cacheFileUploadServiceClient = new CacheFileUploadService.FileUploadServiceSoapClient();
#if DEBUG
            fileName = @"D:\FileUploaderTest\" + fileDescription.FileName;
#endif            
            var cacheUploadResults = cacheFileUploadServiceClient.ParseFile(fileName);
            var uploadResult = new List<UploadResult>();

            foreach (var result in cacheUploadResults)
            {
                uploadResult.Add(
                    new UploadResult() 
                    { 
                         RowNumber = result.Id,
                         File = fileDescription,
                         Message = result.MessageText,
                         Status = (Status)result.RowStatus,
                         FileId = fileDescription.Id
                    }); 
            }

            return uploadResult;
        }
    }
}
