using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DCC_PortfolioSite.Startup))]
namespace DCC_PortfolioSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
