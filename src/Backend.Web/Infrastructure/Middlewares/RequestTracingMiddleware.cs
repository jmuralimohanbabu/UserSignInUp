using System.Threading.Tasks;
using Backend.Common;
using Backend.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Web.Infrastructure.Middlewares
{
    public class RequestTracingMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<RequestTracingMiddleware> _logger;

        public RequestTracingMiddleware(RequestDelegate next, ILogger<RequestTracingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            using (_logger.PushProperty(LoggerKeys.RequestTraceId, context.TraceIdentifier))
            {
                await next(context);
            }
        }
    }
}