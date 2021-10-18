using Microsoft.AspNetCore.Builder;
using WEB_953505_MANKEVICH.Middleware;

namespace WEB_953505_MANKEVICH.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
            IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}