using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoUIWrappersTest.Startup))]
namespace KendoUIWrappersTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
