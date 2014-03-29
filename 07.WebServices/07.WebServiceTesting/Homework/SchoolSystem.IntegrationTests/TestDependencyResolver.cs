using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.WebApi.Controllers;

namespace SchoolSystem.IntegrationTests
{
    class TestDependencyResolver<T> : IDependencyResolver
        where T : class
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(SchoolController))
            {
                return new SchoolController(this.Repository as IRepository<School>);
            }
            else if (serviceType == typeof(StudentController))
            {
                return new StudentController(this.Repository as IRepository<Student>);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}