using DOMAIN.Apae_Administrativo_Excepcionais;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.UnitOfWork.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Apae_Administrativo_Excepcionais.UnitOfWork.Base
{
    public class BaseUnitOfWork<T> : IBaseUnitOfWork<T> where T : DbContext
    {
        protected readonly T _context;

        protected BaseUnitOfWork(T context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
