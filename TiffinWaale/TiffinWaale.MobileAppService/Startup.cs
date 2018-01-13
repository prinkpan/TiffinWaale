using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TiffinWaale.MobileAppService.Startup))]

namespace TiffinWaale.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}