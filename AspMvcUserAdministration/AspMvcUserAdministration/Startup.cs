using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspMvcUserAdministration.Startup))]
namespace AspMvcUserAdministration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
