using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IOC.Apae_Administrativo_Excepcionais.Swagger;
using IOC.Apae_Administrativo_Excepcionais;
using DOMAIN.Apae_Administrativo_Excepcionais;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace API.Apae_Administrativo_Excepcionais
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<Context>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringDB")));



            services
                .AddCustomVersioning()
                .AddCustomSwaggerGen()
                .AddCustomJwtAuthentication()
                .InjectingDependencies()
                .ConfigureAutoMapper();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error/dev");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
                c.RoutePrefix = string.Empty;
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("VALORE_API.API.wwwroot.swagger_ui.index.html");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
