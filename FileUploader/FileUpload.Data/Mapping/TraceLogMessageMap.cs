using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Models.LogModels;

namespace FileUpload.Data.Mapping
{
    public class TraceLogMessageMap:EntityTypeConfiguration<TraceLogMessage>
    {
        public TraceLogMessageMap() 
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Action).IsRequired();
            this.Property(x => x.Controller).IsRequired();
            this.Property(x => x.Message).IsRequired();
            this.Property(x => x.Status).IsRequired();
            this.Property(x => x.TimeStamp).IsRequired();
        }
    }
}
