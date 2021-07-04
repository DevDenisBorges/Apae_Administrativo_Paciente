using APPLICATION.Apae_Administrativo_Excepcionais.Dto;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;

namespace APPLICATION.Apae_Administrativo_Excepcionais.Interface
{
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    public interface IFuncionarioAppService
    {
        Result<Fault, TbFuncionarioDto> Create(TbFuncionarioDto funcionarioDto);
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
