using System.Net.Http.Headers;
using System.Web.Http;
namespace ClientRegistrationApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //Converting all data calls to Json Format
            config.Formatters.JsonFormatter.SupportedMediaTypes
               .Add(new MediaTypeHeaderValue("text/html"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
