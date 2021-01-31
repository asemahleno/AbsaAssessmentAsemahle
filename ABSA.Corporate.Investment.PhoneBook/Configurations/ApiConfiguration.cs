namespace ABSA.Corporate.Investment.PhoneBook.Configurations
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    public static class ApiConfiguration
    {

        public static void ConfigureApiForSwagger(this IServiceCollection services, IConfiguration configuration)
        {

            var swaggerInfo = GetSwaggerInfo(configuration);
            var contact = GetContactInfo(configuration);

            services.AddSwaggerGen(
                swaggerGenOptions =>
                {
                    swaggerGenOptions.SwaggerDoc(
                        swaggerInfo.Version,
                        new OpenApiInfo
                        {
                            Title = $"{swaggerInfo.Description}",
                            Version = swaggerInfo.Version,
                            Contact = new OpenApiContact {Email = contact.Email, Name = contact.Name}
                        });

                    swaggerGenOptions.EnableAnnotations();
                    swaggerGenOptions.CustomSchemaIds(x => x.FullName);
                });
        }

        public static void InitializeOpenApi(this IApplicationBuilder application, IConfiguration configuration)
        {
            var swaggerInfo = GetSwaggerInfo(configuration);

            application.UseSwagger(options => { options.RouteTemplate = swaggerInfo.JsonRoute; });

            application.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint(swaggerInfo.UiEndpoint, "API V1");
                });
        }

        private static SwaggerInfo GetSwaggerInfo(IConfiguration configuration)
        {
            var  swaggerInfo = new SwaggerInfo();

            configuration.GetSection(nameof(SwaggerInfo)).Bind(swaggerInfo);

            return swaggerInfo;
        }

        private static Contact GetContactInfo(IConfiguration configuration)
        {
            var contact = new Contact();

            configuration.GetSection(nameof(Contact)).Bind(contact);

            return contact;
        }

    }
}
