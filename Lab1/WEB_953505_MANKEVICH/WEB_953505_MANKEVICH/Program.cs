using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WEB_953505_MANKEVICH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureLogging(lp =>
                {
                    lp.ClearProviders();
                    lp.AddFilter("Microsoft", LogLevel.None);
                    lp.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.None);
                });
        }
    }
}