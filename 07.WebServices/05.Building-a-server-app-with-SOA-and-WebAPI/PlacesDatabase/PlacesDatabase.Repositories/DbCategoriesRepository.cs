using PlacesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDatabase.Repositories
{
    class Gosho
    {
    }

    public class DbCategoriesRepository : IRepository<Category>
    {
        private DbContext dbContext;
        private DbSet<Category> entitySet;

        public DbCategoriesRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Category>();
        }

        public Category Add(Category item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Category Update(int id, Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Category> All()
        {
            return this.entitySet;
        }

        public IQueryable<Category> Find(System.Linq.Expressions.Expression<Func<Category, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
