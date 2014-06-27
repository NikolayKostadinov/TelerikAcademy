using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models.FileModels;

namespace FileUpload.Models.FileViewModels
{
    public class FileDescriptionViewModel
    {
        public static Expression<Func<FileDescription, FileDescriptionViewModel>> ToFileDescriptionViewModel 
        {
            get 
            {
                return f => new FileDescriptionViewModel()
                {
                    Id= f.Id,
                    FileName = f.FileName,
                    Size = f.Size,
                    UploadTime = f.UploadTime,
                    UserName = f.ApplicationUser.UserName
                };
            }
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }

        public DateTime UploadTime { get; set; }
        public string UserName { get; set; }
    }
}
