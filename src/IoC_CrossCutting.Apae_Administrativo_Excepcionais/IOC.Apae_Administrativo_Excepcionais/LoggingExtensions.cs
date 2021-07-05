using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog.Web;
using System;
using System.Text;

namespace IOC.Apae_Administrativo_Excepcionais
{
    /// <summary>
    /// Extensões de logging
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// Configura o provedor de logs
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder AddCustomLogging(this IHostBuilder builder)
        {
            builder.ConfigureLogging(options =>
            {
                options.ClearProviders();
            }).UseNLog();

            return builder;
        }

        /// <summary>
        /// Grava a mensagem no nível Debug usando parâmetros especificados. Designa eventos informativos refinados que são mais úteis para depurar um aplicativo.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="inputs"></param>
        public static void Debug(this ILogger logger, string message, params object[] inputs)
        {
            logger.LogDebug(FormatMessage(message, inputs));
        }

        /// <summary>
        /// Grava a mensagem no nível Debug usando parâmetros especificados. Designa eventos informativos refinados que são mais úteis para depurar um aplicativo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="inputs"></param>
        public static void Debug<T>(this ILogger<T> logger, string message, params object[] inputs)
        {
            logger.LogDebug(FormatMessage(message, inputs));
        }

        /// <summary>
        /// Grava a mensagem no nível Info. Designa mensagens informativas que destacam o progresso do aplicativo.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        public static void Info(this ILogger logger, string message)
        {
            logger.LogInformation(FormatMessage(message));
        }

        /// <summary>
        /// Grava a mensagem no nível Info. Designa mensagens informativas que destacam o progresso do aplicativo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        public static void Info<T>(this ILogger<T> logger, string message)
        {
            logger.LogInformation(FormatMessage(message));
        }

        /// <summary>
        /// Grava a mensagem e a exceção de diagnóstico no nível Warn. Designa situações potencialmente prejudiciais.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        public static void Warn(this ILogger logger, string message)
        {
            logger.LogWarning(FormatMessage(message));
        }

        /// <summary>
        /// Grava a mensagem e a exceção de diagnóstico no nível Warn. Designa situações potencialmente prejudiciais.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="exception">Uma exceção a ser registrada.</param>
        public static void Warn(this ILogger logger, string message, Exception exception)
        {
            var formattedMessage = FormatMessage(message);
            if (exception == null)
                logger.LogWarning(formattedMessage);
            else
                logger.LogWarning(exception, formattedMessage);
        }

        /// <summary>
        /// Grava a mensagem no nível Warn. Designa situações potencialmente prejudiciais.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>        
        public static void Warn<T>(this ILogger<T> logger, string message)
        {
            logger.LogWarning(FormatMessage(message));
        }

        /// <summary>
        /// Grava a mensagem e a exceção de diagnóstico no nível Warn. Designa situações potencialmente prejudiciais.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="exception">Uma exceção a ser registrada.</param>
        public static void Warn<T>(this ILogger<T> logger, string message, Exception exception)
        {
            var formattedMessage = FormatMessage(message);
            if (exception == null)
                logger.LogWarning(formattedMessage);
            else
                logger.LogWarning(exception, formattedMessage);
        }

        /// <summary>
        /// Grava a mensagem e a exceção de diagnóstico no nível Error. Designa eventos de erro que ainda podem permitir que o aplicativo continue em execução.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="exception">Uma exceção a ser registrada.</param>
        public static void Error(this ILogger logger, string message, Exception exception)
        {
            var formattedMessage = FormatMessage(message);
            if (exception == null)
                logger.LogError(formattedMessage);
            else
                logger.LogError(exception, formattedMessage);
        }

        /// <summary>
        /// Grava a mensagem e a exceção de diagnóstico no nível Error. Designa eventos de erro que ainda podem permitir que o aplicativo continue em execução.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="exception">Uma exceção a ser registrada.</param>
        public static void Error<T>(this ILogger<T> logger, string message, Exception exception)
        {
            var formattedMessage = FormatMessage(message);
            if (exception == null)
                logger.LogError(formattedMessage);
            else
                logger.LogError(exception, formattedMessage);
        }

        /// <summary>
        /// Grava a mensagem e a exceção de diagnóstico no nível Fatal. Designa eventos de erro muito graves que provavelmente levarão o aplicativo a ser interrompido.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="exception">Uma exceção a ser registrada.</param>
        public static void Fatal(this ILogger logger, string message, Exception exception)
        {
            var formattedMessage = FormatMessage(message);
            if (exception == null)
                logger.LogCritical(formattedMessage);
            else
                logger.LogCritical(exception, formattedMessage);
        }


        /// <summary>
        /// Grava a mensagem e a exceção de diagnóstico no nível Fatal. Designa eventos de erro muito graves que provavelmente levarão o aplicativo a ser interrompido.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="message">Uma string a ser escrita.</param>
        /// <param name="exception">Uma exceção a ser registrada.</param>
        public static void Fatal<T>(this ILogger<T> logger, string message, Exception exception)
        {
            var formattedMessage = FormatMessage(message);
            if (exception == null)
                logger.LogCritical(formattedMessage);
            else
                logger.LogCritical(exception, formattedMessage);
        }

        private static readonly string TITLE_MESSAGE = "Mensagem:";
        private static readonly string TITLE_INPUTS = "Parâmetros:";

        private static string FormatMessage(string message, params object[] inputs)
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(message))
            {
                builder.Append(TITLE_MESSAGE);
                builder.Append(message);
            }
            if (inputs != null && inputs.Length > 0)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    builder.Append(Environment.NewLine);
                }
                builder.Append(TITLE_INPUTS);
                foreach (var input in inputs)
                {
                    builder.Append(Environment.NewLine);
                    builder.Append(JsonConvert.SerializeObject(input, Formatting.Indented));
                }
            }
            return builder.ToString();
        }

        private static string FormatMessage(string message) => !string.IsNullOrEmpty(message) ? $"{TITLE_MESSAGE} {message}" : "";
    }
}
