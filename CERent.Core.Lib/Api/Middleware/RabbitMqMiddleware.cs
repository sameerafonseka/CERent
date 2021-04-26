using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Core.Lib.Api.Middleware
{
    public class RabbitMqMiddleware
    {
        private readonly ILogger<LoggingMiddleware> logger;
        private readonly RequestDelegate next;

        public RabbitMqMiddleware(ILogger<LoggingMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            logger.LogInformation($"About to start {context.Request.Method} {context.Request.GetDisplayUrl()} request");

            await next(context);

            logger.LogInformation($"Request completed with status code: {context.Response.StatusCode} ");
        }
    }
}
