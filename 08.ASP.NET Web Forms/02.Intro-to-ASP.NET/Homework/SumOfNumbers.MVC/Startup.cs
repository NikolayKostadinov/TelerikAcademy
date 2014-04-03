using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SumOfNumbers.MVC.Startup))]
namespace SumOfNumbers.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
