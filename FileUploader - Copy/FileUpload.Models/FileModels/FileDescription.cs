using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Models.FileModels
{
    public class FileDescription
    {
        public FileDescription()
        {
            this.UploadResults = new HashSet<UploadResult>();
        }

        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }

        public DateTime UploadTime { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<UploadResult> UploadResults { get; set; }

    }
}
