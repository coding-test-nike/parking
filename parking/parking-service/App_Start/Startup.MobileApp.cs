using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Config;

using Owin;

namespace parking_service
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.EnableCors();
            config.MapHttpAttributeRoutes();

            //for regular non-mobile app controllers
            config.Routes.MapHttpRoute(
                     name: "DefaultApi",
                     routeTemplate: "api/{controller}/{id}",
                     defaults: new { id = RouteParameter.Optional });


            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

  
            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

 

            app.UseWebApi(config);
        }
    }
 
}

