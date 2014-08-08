using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfoSystem.Data.Repositories
{
    public interface IRepository<T,I>
        where T : class
    {
        IQueryable<T> All();

        T GetById(I id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(I id);

        void Detach(T entity);
    }
}

