using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileUpload.App_Start.Startup))]
namespace FileUpload.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
