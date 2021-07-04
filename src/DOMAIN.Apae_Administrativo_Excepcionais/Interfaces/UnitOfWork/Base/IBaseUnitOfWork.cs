using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork.Base
{
    public interface IBaseUnitOfWork<T> where T : DbContext
    {
        public int Save();
        public void Dispose();
    }
}
