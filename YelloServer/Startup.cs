using Domain.Entities;
using Infrastructure.Services.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YelloServer;

public class Startup
{
    // Init startup
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Add SignalR to services 
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapHub<ChatHub>($"/{ServerRoutes.CHAT_ROOMS}"); });
    }
}