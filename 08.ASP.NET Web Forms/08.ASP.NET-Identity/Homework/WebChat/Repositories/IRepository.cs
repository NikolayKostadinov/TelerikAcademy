using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Repositories
{
    interface IRepository<T> 
         where T : class
    {
        ICollection<T> All();
        T GetById(int Id);

        void AddNew(T item);

        void Update(T item);

        void Delete(T item);
    }
}
