using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace IOC.Apae_Administrativo_Excepcionais
{
    /// <summary>
    /// Extensões de autenticação
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Configura a autenticação por JWT usando as configurações do SSC
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomJwtAuthentication(this IServiceCollection services)
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));
            var issuerEnvironment = Environment.GetEnvironmentVariable("JWT_ISSUER");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = issuerEnvironment,
                    ValidateAudience = false
                };
            }); ;

            return services;
        }
    }
}
