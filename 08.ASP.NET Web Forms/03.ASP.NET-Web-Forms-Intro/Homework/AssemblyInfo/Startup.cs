using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssemblyInfo.Startup))]
namespace AssemblyInfo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
