using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using Serilog.Core;
using System.Globalization;

namespace ThirdPartyAuthTest.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("----------------------Nueva solicitud--------------------");
            _logger.LogInformation("---------------------------------------------------------");
            _logger.LogInformation("Metodo: {Metodo}",context.Request.Method);
            _logger.LogInformation("Numero de headers: {Count}",context.Request.Headers.Count);
            _logger.LogInformation("Es HTTPS: {EsHTTPS}", context.Request.IsHttps);
            _logger.LogInformation("URL: {URL}", context.Request.GetDisplayUrl());
            _logger.LogInformation("---------------------------------------------------------");
            _logger.LogInformation("----------------------Fin Nueva solicitud----------------");
            await _next(context);
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
