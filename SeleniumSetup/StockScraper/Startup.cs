using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockScraper.Startup))]
namespace StockScraper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
