using APPLICATION.Apae_Administrativo_Excepcionais.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOC.Apae_Administrativo_Excepcionais
{
    /// <summary>
    /// Extensões do AutoMapper
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Adiciona configurações para o AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToEntity));

            return services;
        }
    }
}
