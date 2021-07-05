using IoC_CrossCutting.Apae_Administrativo_Excepcionais.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using VALORE_API.CrossCutting.IoC.Extensions.Swagger;

namespace IOC.Apae_Administrativo_Excepcionais.Swagger
{
    /// <summary>
    /// Extensões do SwaggerGen
    /// </summary>
    public static class SwaggerGenExtensions
    {
        /// <summary>
        /// Configuração básica do SwaggerGen
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(c =>
            {
                c.AddFluentValidationRules();
                c.OperationFilter<SwaggerDefaultValues>();
                c.OperationFilter<BearerAuthenticationFilter>();
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"Api.xml"), true);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"Application.xml"), true);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
            });

            return services;
        }
    }
}
