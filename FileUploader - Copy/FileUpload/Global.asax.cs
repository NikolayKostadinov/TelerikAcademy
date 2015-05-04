using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FileUpload
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FileUpload.App_Start.FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            FileUpload.App_Start.RouteConfig.RegisterRoutes(RouteTable.Routes);
            FileUpload.App_Start.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
