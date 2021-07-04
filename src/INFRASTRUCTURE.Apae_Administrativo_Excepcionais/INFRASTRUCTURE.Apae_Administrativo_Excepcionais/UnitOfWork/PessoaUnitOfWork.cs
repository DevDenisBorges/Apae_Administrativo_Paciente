using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRASTRUCTURE.Apae_Administrativo_Excepcionais.UnitOfWork
{
    public class PessoaUnitOfWork : IPessoaUnitOfWork
    {
        public IPessoaReporitory pessoaRepository { get; }
        public PessoaUnitOfWork(IPessoaReporitory pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }
    }
}
