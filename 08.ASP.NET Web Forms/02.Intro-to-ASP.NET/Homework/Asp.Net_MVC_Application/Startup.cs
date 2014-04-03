using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Asp.Net_MVC_Application.Startup))]
namespace Asp.Net_MVC_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
