using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockWebScraperApp.Startup))]
namespace StockWebScraperApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
