using DOMAIN.Apae_Administrativo_Excepcionais;
using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using DOMAIN.Apae_Administrativo_Excepcionais.Types.Result;
using INFRASTRUCTURE.Apae_Administrativo_Excepcionais.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFRASTRUCTURE.Apae_Administrativo_Excepcionais.Repositories
{
    public class PessoaRepository : BaseRepository<TbPessoa>, IPessoaReporitory
    {
        public PessoaRepository(Context context) : base(context)
        {
        }

        public Result<Fault, TbPessoa> FindByCpf(decimal cpf) {
            return List().BiMap<Fault, TbPessoa>(x => x, x => x.FirstOrDefault());
        }
    }
}
