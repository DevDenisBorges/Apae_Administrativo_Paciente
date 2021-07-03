using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Types.Result
{ 
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TFailure"></typeparam>
    /// <typeparam name="TSuccess"></typeparam>
    public class Failure<TFailure, TSuccess> : Result<TFailure, TSuccess>
    {
        /// <summary>
        /// 
        /// </summary>
        public TFailure Value { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="failure"></param>
        public Failure(TFailure failure)
        {
            Value = failure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TFailure2"></typeparam>
        /// <typeparam name="TSuccess2"></typeparam>
        /// <param name="ifFailure"></param>
        /// <param name="ifSuccess"></param>
        /// <returns></returns>
        public override Result<TFailure2, TSuccess2> BiMap<TFailure2, TSuccess2>(Func<TFailure, TFailure2> ifFailure, Func<TSuccess, TSuccess2> ifSuccess)
            => new Failure<TFailure2, TSuccess2>(ifFailure(Value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSuccess2"></typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public override Result<TFailure, TSuccess2> Bind<TSuccess2>(Func<TSuccess, Result<TFailure, TSuccess2>> f)
            => new Failure<TFailure, TSuccess2>(Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ifFailure"></param>
        /// <param name="ifSuccess"></param>
        /// <returns></returns>
        public override T FromResult<T>(Func<TFailure, T> ifFailure, Func<TSuccess, T> ifSuccess)
            => ifFailure(Value);
    }
}
