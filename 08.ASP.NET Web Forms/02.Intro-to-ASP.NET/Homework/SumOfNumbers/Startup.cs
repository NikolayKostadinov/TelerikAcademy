using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SumOfNumbers.Startup))]
namespace SumOfNumbers
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
