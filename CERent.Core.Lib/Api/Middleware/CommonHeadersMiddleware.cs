using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Core.Lib.Api.Middleware
{
    public class CommonHeadersMiddleware
    {
        private readonly ILogger<CommonHeadersMiddleware> logger;
        private readonly RequestDelegate next;

        public CommonHeadersMiddleware(ILogger<CommonHeadersMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            if(context.Items["CorrelationId"] == null || !String.IsNullOrEmpty(context.Items["CorrelationId"].ToString()))
            {
                var correlationId = Guid.NewGuid().ToString();

                logger.LogInformation($"Setting correlationId:{correlationId}");
                context.Items["CorrelationId"] = correlationId;
                context.Response.Headers["CorrelationId"] = correlationId;
            }

            await next(context);
        }
    }
}

