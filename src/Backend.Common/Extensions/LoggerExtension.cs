using System;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Backend.Common.Extensions
{
    public static class LoggerExtension
    {
        public static IDisposable PushProperty(this ILogger logger, string propertyName, object value)
        {
            try
            {
                return LogContext.PushProperty(propertyName, value);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, $"Error pushing property- {propertyName} into log context");
                return default;
            }
        }
    }
}