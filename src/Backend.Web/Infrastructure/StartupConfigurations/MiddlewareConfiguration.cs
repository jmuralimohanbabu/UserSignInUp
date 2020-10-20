using Backend.Web.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Backend.Web.Infrastructure.StartupConfigurations
{
    public static class MiddlewareConfiguration
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
        { 
            return app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            { 
                appBuilder.UseMiddleware<RequestTracingMiddleware>();
            })
                .UseMiddleware<ErrorHandlingMiddleware>();
        }        
    }
}