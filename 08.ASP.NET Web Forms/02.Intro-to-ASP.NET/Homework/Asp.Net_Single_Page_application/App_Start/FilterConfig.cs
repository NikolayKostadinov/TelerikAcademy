using System.Web;
using System.Web.Mvc;

namespace Asp.Net_Single_Page_application
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
