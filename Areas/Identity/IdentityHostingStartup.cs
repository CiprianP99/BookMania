using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BookMania.Areas.Identity.IdentityHostingStartup))]
namespace BookMania.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}