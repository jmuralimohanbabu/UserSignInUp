using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Web.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "General exception occurred");
                await SendInternalServerErrorResult(context, ex.Message);
            }            
        }

        private async Task SendInternalServerErrorResult(HttpContext context, string message)
        {
            var problemDetails = new ProblemDetails();
            problemDetails.Title = "General exception occurred";
            problemDetails.Status = (int) HttpStatusCode.InternalServerError;
            problemDetails.Instance = context.Request.Scheme;
            problemDetails.Type = HttpStatusCode.InternalServerError.ToString();
            problemDetails.Detail = message;
            var result = JsonSerializer.Serialize(problemDetails);
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(result);
        }
    }
}