using System.Web.Mvc;
using FileUpload.Infrastructure;

namespace FileUpload.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogResultFilterAttribute());
        }
    }
}
