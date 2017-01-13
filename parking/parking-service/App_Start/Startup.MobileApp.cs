using System.Web.Http;
using Microsoft.Azure.Mobile.Server;

using Owin;
using parking_service.Framework;
using System.Web.Http.ExceptionHandling;

namespace parking_service
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.EnableCors();
            config.Filters.Add(new CustomExceptionFilterAttribute());
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new CheckRequest());


            config.Routes.MapHttpRoute(
                     name: "DefaultApi",
                     routeTemplate: "api/{controller}/{id}",
                     defaults: new { id = RouteParameter.Optional });
 
            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            app.UseWebApi(config);
        }
    }
 
}

