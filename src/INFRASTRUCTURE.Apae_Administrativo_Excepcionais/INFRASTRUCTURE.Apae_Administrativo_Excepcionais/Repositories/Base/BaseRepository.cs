using DOMAIN.Apae_Administrativo_Excepcionais;
using DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository.Base;
using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using DOMAIN.Apae_Administrativo_Excepcionais.Types.Result;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace INFRASTRUCTURE.Apae_Administrativo_Excepcionais.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(Context context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public Result<Fault, TEntity> Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return new Success<Fault, TEntity>(entity);
        }

        public Result<Fault, TEntity> DeleteById(long id)
        {
            var search = _dbSet.Find(id);
            if (search == null)
                return new Failure<Fault, TEntity>(new Fault { Message = $"Não foi possivel encontrar a Entidade!" });

            _dbSet.Remove(search);
            return new Success<Fault, TEntity>(search);
        }



        public Result<Fault, TEntity> FindById(long id)
        {
            var search = _dbSet.Find(id);
            if (search == null)
                return new Failure<Fault, TEntity>(new Fault { Message = $"Não foi possivel encontrar a Entidade!" });

            _dbSet.Find(search);
            return new Success<Fault, TEntity>(search);
        }

        public Success<Fault, IEnumerable<TEntity>> List()
        {
            var searchAll = _dbSet.ToList();
            return new Success<Fault, IEnumerable<TEntity>>(searchAll);
        }


        public Result<Fault, TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return new Success<Fault, TEntity>(entity);
        }


    }
}
