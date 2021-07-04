using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Services
{
    public interface IPessoaService
    {
        IPessoaUnitOfWork pessoaUnitOfWork { get; }
        Result<Fault, TbPessoa> Create(TbPessoa pessoa);
    }
}
