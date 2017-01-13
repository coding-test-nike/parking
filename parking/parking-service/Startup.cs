using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(parking_service.Startup))]

namespace parking_service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}