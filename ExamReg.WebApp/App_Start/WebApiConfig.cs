using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using System.Web.Http;

namespace ExamReg.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
      // Web API configuration and services

      // Web API routes
      //config.MapHttpAttributeRoutes();

      // Set JSON formatter as default one and remove XmlFormatter

      var jsonFormatter = config.Formatters.JsonFormatter;

      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

      // Remove the XML formatter
      config.Formatters.Remove(config.Formatters.XmlFormatter);

      jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
      config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
      // Enable CORS for the Vue App
      var cors = new EnableCorsAttribute("http://localhost:8080", "*", "*");
      config.EnableCors(cors);
    }
  }
}
