using System;
using System.Collections.Generic;

using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models.FileModels;

namespace FileUpload.Data.Mapping
{
    public class FileDescriptionMap : EntityTypeConfiguration<FileDescription>
    {
        public FileDescriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FileName)
                .IsRequired();

            this.Property(t => t.Size)
                .IsRequired();
        }
    }
}
