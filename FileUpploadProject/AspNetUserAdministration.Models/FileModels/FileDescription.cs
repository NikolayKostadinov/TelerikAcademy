using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FileUpload.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FileUpload.Models.FileModels
{
    public class FileDescription
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public Guid UserId { get; set; }

    }
}
