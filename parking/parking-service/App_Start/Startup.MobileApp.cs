using System.Web.Http;
using Microsoft.Azure.Mobile.Server;

using Owin;
using parking_service.Framework;
using System.Web.Http.ExceptionHandling;
using Swashbuckle.Application;
using System.Web.Http.Description;
using Microsoft.Azure.Mobile.Server.Swagger;

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
 
            //MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            app.UseWebApi(config);
            ConfigureSwagger(config);


        }

        public static void ConfigureSwagger(HttpConfiguration config)
        {
            // Use the custom ApiExplorer that applies constraints. This prevents
            // duplicate routes on /api and /tables from showing in the Swagger doc.
            config.Services.Replace(typeof(IApiExplorer), new MobileAppApiExplorer(config));
            config
               .EnableSwagger(c =>
               {
                   c.SingleApiVersion("v1", "Sample web api framework for the NIKE coding assignment");

               // Tells the Swagger doc that any MobileAppController needs a
               // ZUMO-API-VERSION header with default 2.0.0
               c.OperationFilter<MobileAppHeaderFilter>();

               // Looks at attributes on properties to decide whether they are readOnly.
               // Right now, this only applies to the DatabaseGeneratedAttribute.
               c.SchemaFilter<MobileAppSchemaFilter>();
               
               })
               .EnableSwaggerUi();
        }
    }
 
}

