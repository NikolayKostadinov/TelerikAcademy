using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models;
using FileUpload.Models.FileModels;

namespace FileUpload.Models.FileModels
{
    public class UploadResult
    {
        [Key]
        public int Id { get; set; }
        public string RowNumber { get; set; }
        public string  Message { get; set; }
        public Status Status { get; set; }
        public int FileId { get; set; }
        public virtual FileDescription File { get; set; }
    }
}
