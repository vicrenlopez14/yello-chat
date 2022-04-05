using Domain.Entities;
using Infrastructure.Services.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YelloServer;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
    }

    private void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapHub<ChatHub>($"/{ServerRoutes.CHAT_ROOMS}"); });
    }
}