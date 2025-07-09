using System.Net.Http.Headers;
using System.Web.Http;

namespace APIRvMedical
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // ✅ Forcer le format de réponse en JSON par défaut
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("text/html")
            );

            // ❌ Supprimer le formatter XML (optionnel)
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // ✅ Activer le routage basé sur les attributs ([Route])
            config.MapHttpAttributeRoutes();

            // ✅ Définir la route par défaut
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
