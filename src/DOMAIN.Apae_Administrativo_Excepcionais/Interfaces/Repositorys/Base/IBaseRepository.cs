using DOMAIN.Apae_Administrativo_Excepcionais.Types;
using DOMAIN.Apae_Administrativo_Excepcionais.Types.Result;
using System.Collections.Generic;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Interfaces.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtém por Id
        /// </summary>
        /// <param name="id">Chave principal</param>
        /// <returns>Resultado da pesquisa</returns>
        Result<Fault, TEntity> FindById(long id);

        /// <summary>
        /// Obtém todos com os includes listados
        /// </summary>
        /// <returns>IEnumerable  TEntity</returns>
        Success<Fault, IEnumerable<TEntity>> List();

        /// <summary>
        /// Insere uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Resultado da tentativa de inserção</returns>
        Result<Fault, TEntity> Create(TEntity entity);
        /// <summary>
        /// Altera uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Retorna resultado da tentativa de atualizar</returns>
        Result<Fault, TEntity> Update(TEntity entity);
        /// <summary>
        /// Exclui uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Retorna resultado da  tentativa de deletar a entity</returns>
        Result<Fault, TEntity> DeleteById(long id);
        /// <summary>
        /// Método que salva todas as inserções/alterações/exclusões
        /// </summary>
        /// <returns></returns>
    }
}
