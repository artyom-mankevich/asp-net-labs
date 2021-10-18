using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WEB_953505_MANKEVICH.Middleware
{
    public class LogMiddleware
    {
        private readonly ILogger<LogMiddleware> _logger;
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next,
            ILogger<LogMiddleware> logger)

        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode != StatusCodes.Status200OK)
            {
                var path = context.Request.Path +
                           context.Request.QueryString;
                _logger.LogInformation($"Request {path}" +
                                       $" returns status code {context.Response.StatusCode.ToString()}");
            }
        }
    }
}