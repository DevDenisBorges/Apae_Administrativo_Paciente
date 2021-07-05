using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IoC_CrossCutting.Apae_Administrativo_Excepcionais.Swagger
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly OpenApiInfo _info;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        /// <param name="info">Api Info provider</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IOptions<OpenApiInfo> info)
        {
            _provider = provider;
            _info = info.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                _info.Version = description.ApiVersion.ToString() +
                    (description.IsDeprecated ? " Esta versão da API está obsoleta e será removida em uma versão futura." : "");
                options.SwaggerDoc(description.GroupName, _info);
            }
        }
    }
}

