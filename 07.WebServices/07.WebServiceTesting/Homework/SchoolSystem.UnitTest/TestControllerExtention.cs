using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace SchoolSystem.UnitTest
{
    /// <summary>
    /// Creating faik controller context and request
    /// </summary>
    public static class TestControllerExtention
    {
        public static void SetupControllerForTest(
            this ApiController controller,
            HttpMethod method,
            string baseUrl,
            string controllerName)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(method, baseUrl + controllerName);
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", controllerName);
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }
    }
}