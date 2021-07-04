using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Services;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Services
{
    public class PessoaService : IPessoaService
    {
        public IPessoaUnitOfWork pessoaUnitOfWork { get; }
        public PessoaService(IPessoaUnitOfWork pessoaUnitOfWork)
        {
            this.pessoaUnitOfWork = pessoaUnitOfWork;
        }

        public Result<Fault, TbPessoa> Create(TbPessoa pessoa)
            => pessoaUnitOfWork.pessoaRepository.Create(pessoa);
    }
}
