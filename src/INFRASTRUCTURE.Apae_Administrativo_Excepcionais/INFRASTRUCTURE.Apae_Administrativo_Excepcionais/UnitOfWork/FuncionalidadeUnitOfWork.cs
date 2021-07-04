using DOMAIN.Apae_Administrativo_Excepcionais;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork;
using INFRASTRUCTURE.Apae_Administrativo_Excepcionais.UnitOfWork.Base;

namespace INFRASTRUCTURE.Apae_Administrativo_Excepcionais.UnitOfWork
{
    public class FuncionalidadeUnitOfWork : BaseUnitOfWork<Context>, IFuncionarioUnitOfWork
    {
        public FuncionalidadeUnitOfWork(IFuncionarioRepository funcionarioRepository, IPessoaReporitory pessoaRepository, Context context):base(context)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.pessoaRepository = pessoaRepository;
            Context = context;
        }

        public IFuncionarioRepository funcionarioRepository { get; }

        public IPessoaReporitory pessoaRepository { get; }
        public Context Context { get; }
    }
}
