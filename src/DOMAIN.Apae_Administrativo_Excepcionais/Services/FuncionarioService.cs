using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Services;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using DOMAIN.Apae_Administrativo_Excepcionais.Types.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioUnitOfWork _funcionarioUnitOfWork;
        public FuncionarioService(IFuncionarioUnitOfWork funcionarioUnitOfWork)
        {
            _funcionarioUnitOfWork = funcionarioUnitOfWork;
        }

        public Result<Fault, TbFuncionario> Create(TbFuncionario funcionario)
            => _funcionarioUnitOfWork.pessoaRepository.FindByCpf(funcionario.CdPessoaNavigation.NrCpf)
                .Bind<TbFuncionario>(x => {
                    if (x != null)
                        return new Failure<Fault, TbFuncionario>(new Fault() { 
                            Message = "Usuario já cadastrado",
                            StatusCode = 404
                        });

                    funcionario.CdPessoaNavigation = x;
                    _funcionarioUnitOfWork.funcionarioRepository.Create(funcionario);
                    _funcionarioUnitOfWork.Save();
                    return new Success<Fault, TbFuncionario>(funcionario);
                });

    }
}
