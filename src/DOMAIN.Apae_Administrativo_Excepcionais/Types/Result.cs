using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Apae_Administrativo_Excepcionais.Types
{
    /// <summary>
    /// Essa classe representa uma ação que pode retornar erros (TFailure) ou um valor (TSuccess) de resultado 
    /// </summary>
    /// <typeparam name="TFailure"></typeparam>
    /// <typeparam name="TSuccess"></typeparam>
    public abstract class Result<TFailure, TSuccess>
    {
        /// <summary>
        /// Mapeia o valor contido no Result de acordo com as funções passadas como argumento.
        /// <para/> Result é um bifunctor, e para tal as seguintes leis devem ser seguidas:
        /// <para/> y.BiMap(x => x, x => x) ≡ y
        /// <para/> y.BiMap(f1, f2).BiMap(f3, f4) ≡ y.BiMap(x => f3(f1(x)), x => f4(f2(x)));
        /// </summary>
        /// <example>
        /// Uso:
        /// <code>
        /// new Failure(5).BiMap(l => l + 1, x => x + " mundo!"); // Failure(6)
        /// new Success("ola").BiMap(l => l + 1, x => x + " mundo!"); // Success("ola mundo!")
        /// </code>
        /// </example>
        /// <typeparam name="TFailure2">Novo tipo para o caso Failure</typeparam>
        /// <typeparam name="TSuccess2">Novo tipo para o caso Success</typeparam>
        /// <param name="ifFailure">função executada caso o valor interno seja Failure</param>
        /// <param name="ifSuccess">função executada caso o valor interno seja Success</param>
        /// <returns></returns>
        public abstract Result<TFailure2, TSuccess2> BiMap<TFailure2, TSuccess2>(
            Func<TFailure, TFailure2> ifFailure, Func<TSuccess, TSuccess2> ifSuccess);

        /// <summary>
        /// Bind aplica uma função que pode falhar (também retorna um Result) a um Result
        /// <para/> Result é uma mônada <seealso href="https://stackoverflow.com/a/10245311" />
        /// e para tal as seguintes leis devem ser seguidas:
        /// 
        /// 
        /// </summary>
        /// <example>
        /// Uso:
        /// <code>
        /// var even2 = (x) => x % 2 == 0 ? new Success(x) : new Failure("erro: número ímpar"); 
        /// new Failure("outro erro").Bind(x => even2(x)); // Failure("outro erro")
        /// new Success(4).Bind(x => even2(x)); // Success(4)
        /// new Success(5).Bind(x => even2(x)); // Failure("erro: número ímpar")
        /// </code>
        /// </example>
        /// <typeparam name="TSuccess2">Novo tipo para o caso de sucesso</typeparam>
        /// <param name="f"></param>
        /// <returns></returns>
        public abstract Result<TFailure, TSuccess2> Bind<TSuccess2>(
            Func<TSuccess, Result<TFailure, TSuccess2>> f);

        /// <summary>
        /// Função para colapsar o tipo Result em um tipo que seja útil para o programa
        /// </summary>
        /// <typeparam name="T">Tipo final</typeparam>
        /// <param name="ifFailure">Conversão para caso o valor seja Failure</param>
        /// <param name="ifSuccess">Conversão para caso o valor seja Success</param>
        /// <returns></returns>
        public abstract T FromResult<T>(Func<TFailure, T> ifFailure, Func<TSuccess, T> ifSuccess);
    }
}
