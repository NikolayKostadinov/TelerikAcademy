using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using SchoolSystem.Data;
using SchoolSystem.Repository;

namespace SchoolSystem.WebApi.App_Start
{
    public class AutofacWebAPI
    {

        public static void Initialize(HttpConfiguration config)
        {

            Initialize(config,
                RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {

            config.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // EF DbContext
            builder.RegisterType<SchoolContext>()
                   .As<DbContext>()
                   .InstancePerApiRequest();

            // Register repositories by using Autofac's OpenGenerics feature
            // More info: http://code.google.com/p/autofac/wiki/OpenGenerics
            builder.RegisterGeneric(typeof(EfRepository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerApiRequest();

            return builder.Build();
        }
    }
}