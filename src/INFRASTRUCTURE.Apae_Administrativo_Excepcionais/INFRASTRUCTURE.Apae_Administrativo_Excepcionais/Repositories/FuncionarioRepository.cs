using DOMAIN.Apae_Administrativo_Excepcionais;
using DOMAIN.Apae_Administrativo_Excepcionais.Entities;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using INFRASTRUCTURE.Apae_Administrativo_Excepcionais.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRASTRUCTURE.Apae_Administrativo_Excepcionais.Repositories
{
    public class FuncionarioRepository : BaseRepository<TbFuncionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(Context context) : base(context)
        {
        }

    }
}
