using APPLICATION.Apae_Administrativo_Excepcionais.AppService;
using APPLICATION.Apae_Administrativo_Excepcionais.Interface;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Services;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork;
using DOMAIN.Apae_Administrativo_Excepcionais.Services;
using INFRASTRUCTURE.Apae_Administrativo_Excepcionais.Repositories;
using INFRASTRUCTURE.Apae_Administrativo_Excepcionais.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.Apae_Administrativo_Excepcionais
{
    /// <summary>
    /// Extensões da Injerção de Dependências
    /// </summary>
    public static class DependencyInjectionExtensions
    {

        /// <summary>
        /// Adiciona configuração das interfaces e suas implementações 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection InjectingDependencies(this IServiceCollection services)
        {
            //UnitOfWork 
            services.AddScoped<IFuncionarioUnitOfWork, FuncionalidadeUnitOfWork>();
            services.AddScoped<IPessoaUnitOfWork, PessoaUnitOfWork>();

            //AppServices
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();
            services.AddScoped<IPessoaAppService, IPessoaAppService>();

            //Services
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            // services.AddScoped<IPessoaService, IPessoaService>();

            //Repository
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IPessoaReporitory, PessoaRepository>();

            return services;
        }
    }
}
