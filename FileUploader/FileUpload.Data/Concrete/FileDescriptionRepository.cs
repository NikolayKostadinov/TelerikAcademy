using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUpload.Data;
using FileUpload.Data.Abstract;
using FileUpload.Models.FileModels;
using System.Data.Entity.Infrastructure;

namespace FileUpload.Data.Concrete
{
    public class FileDescriptionRepository : GenericRepository<FileDescription,int>
    {
        public FileDescriptionRepository(DbContext context):base(context)
        {
        }

        public override IQueryable<FileDescription> All()
        {
            return this.DbSet.Include("ApplicationUser").Include("UploadResults").AsQueryable();
        }  

        /// <summary>
        /// Bulks the insert.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public override void BulkInsert(IEnumerable<FileDescription> entities)
        {
            ((DbSet<FileDescription>)this.DbSet).AddRange(entities);
        }
    }
}
