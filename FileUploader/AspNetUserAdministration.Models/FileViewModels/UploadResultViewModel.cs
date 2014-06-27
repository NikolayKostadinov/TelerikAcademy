using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models.FileModels;

namespace FileUpload.Models.FileViewModels
{
    public class UploadResultViewModel
    {
        public static Expression<Func<UploadResult, UploadResultViewModel>> ToUploadResultViewModel
        {
            get 
            {
                return ur => new UploadResultViewModel()
                {
                    Id=ur.Id,
                    RowNumber = ur.RowNumber,
                    Message = ur.Message,
                    Status = ur.Status,
                    FileName = ur.File.FileName
                };
            }
        }
        public int Id { get; set; }
        public long RowNumber { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
        public string FileName { get; set; }
    }
}
