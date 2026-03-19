using Ideator.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using TheAppManager.Modules;

namespace Ideator.API.Modules;

/// <summary>
/// Registers domain and application-layer services.
/// </summary>
public sealed class DomainServicesModule : IAppModule
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.ConfigureDomainServices();
    }

    public void ConfigureMiddleware(WebApplication app)
    {
        // No middleware for this module.
    }

    public void ConfigureEndpoints(IEndpointRouteBuilder endpoints)
    {
        // No endpoints for this module.
    }
}
