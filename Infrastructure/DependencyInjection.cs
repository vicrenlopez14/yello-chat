using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure;

public class DependencyInjection
{
    static void Init(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
}