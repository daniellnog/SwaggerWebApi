using System.Web.Http;
using WebActivatorEx;
using SwaggerWebAPI;
using Swashbuckle.Application;
using System;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwaggerWebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SwaggerWebAPI");

                        c.IgnoreObsoleteActions();
                        c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\SwaggerWebAPI.XML");
                        c.IgnoreObsoleteProperties();

                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Exemplo de utilização do Swagger");
                        c.DocExpansion(DocExpansion.List);
                    });
        }
    }
}
