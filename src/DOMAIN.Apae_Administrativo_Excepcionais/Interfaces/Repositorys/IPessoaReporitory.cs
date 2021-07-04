using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository.Base;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository
{
    public interface IPessoaReporitory : IBaseRepository<TbPessoa>
    {
        Result<Fault, TbPessoa> FindByCpf(decimal cpf);
    }
}
