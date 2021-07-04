using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork
{
    public interface IPessoaUnitOfWork
    {
        IPessoaReporitory pessoaRepository { get; }
    }
}
