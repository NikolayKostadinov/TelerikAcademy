using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models;
using FileUpload.Models.FileModels;

namespace FileUpload.Utility
{
    public class FuleUploadUtility
    {
        /// <summary>
        /// Persists the result.
        /// </summary>
        /// <param name="upploadResult">The uppload result.</param>
       
        public static ICollection<UploadResult> ParseFile(string fileName, FileDescription fileDescription)
        {
            var cacheFileUploadServiceClient = new CacheFileUploadService.FileUploadServiceSoapClient();
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
