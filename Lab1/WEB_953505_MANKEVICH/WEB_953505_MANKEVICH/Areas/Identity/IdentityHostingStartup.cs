using Microsoft.AspNetCore.Hosting;
using WEB_953505_MANKEVICH.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace WEB_953505_MANKEVICH.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}