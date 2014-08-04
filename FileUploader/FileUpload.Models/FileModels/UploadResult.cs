using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public long RowNumber { get; set; }
        public string  Message { get; set; }
        public Status Status { get; set; }
        
        [ForeignKey("File")]
        public int FileId { get; set; }
        public virtual FileDescription File { get; set; }
    }
}
