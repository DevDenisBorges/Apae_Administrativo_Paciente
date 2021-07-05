using APPLICATION.Apae_Administrativo_Excepcionais.Dto;
using APPLICATION.Apae_Administrativo_Excepcionais.Interface;
using AutoMapper;
using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Services;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;

namespace APPLICATION.Apae_Administrativo_Excepcionais.AppService
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionarioAppService(IFuncionarioService funcionarioService, IMapper mapper)
        {
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        public Result<Fault, TbFuncionarioDto> Create(TbFuncionarioDto funcionarioDto)
            => _funcionarioService.Create(_mapper.Map<TbFuncionario>(funcionarioDto))
                .BiMap<Fault, TbFuncionarioDto>(x => x, x => _mapper.Map<TbFuncionarioDto>(x));
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
