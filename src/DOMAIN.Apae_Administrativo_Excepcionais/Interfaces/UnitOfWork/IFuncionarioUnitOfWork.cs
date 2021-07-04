using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork.Base;
using DOMAIN.Apae_Administrativo_Excepcionais;
using Microsoft.EntityFrameworkCore;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork
{
    public interface IFuncionarioUnitOfWork : IBaseUnitOfWork<DbContext>
    {
        IFuncionarioRepository funcionarioRepository { get; }
        IPessoaReporitory pessoaRepository { get; }
    }
}
