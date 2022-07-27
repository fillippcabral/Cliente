using Cliente.Core.Extensoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Cliente.Core.AspNetCoreWebApi
{
    public class MiddlewareDeErros
    {
        private const string CodigoDeErro = "[Erro_Dominio]";
        private readonly RequestDelegate _next;
        private readonly ILogger<ControllerBase> _logger;

        public MiddlewareDeErros(RequestDelegate next, ILogger<ControllerBase> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception ex)
            {
                await TratarExcecao(context, ex);

            }

        }

        private Task TratarExcecao(HttpContext context, Exception ex)
        {
            ErroDTO erro;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment != "Development" && environment != "Qa")
                erro = new ErroDTO($"Tivemos um problema, por favor, verique os logs.");
            else
                erro = new ErroDTO(ex.InnerExceptionRaiz(), ex);

            var referencia = $" - Ref.: {erro.Id} - ";

            _logger.LogError(CodigoDeErro + referencia + ex.InnerExceptionRaiz());

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/problem+json";
            return context.Response.WriteAsync(JsonConvert.SerializeObject(false));

        }
    }
}


