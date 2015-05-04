using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models.FileModels;

namespace FileUpload.Models.LogModels
{
    public class TraceLogMessage
    {
        [Key]
        public int Id { get; set; }
        [Index(IsClustered = true, IsUnique = false)]
        public DateTime TimeStamp  { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
    }
}
