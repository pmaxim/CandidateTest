using Microsoft.Extensions.DependencyInjection;
using WebUi.Infrastructure.Models;
using WebUi.Infrastructure.Services;
using WebUi.Infrastructure.Services.Interfaces;

namespace WebUi.Infrastructure.Utils;

public static class InfrastructureServiceProvider
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        // TODO Implement options pattern
        services.AddOptions<AstridsoftOptions>();
        services.AddScoped<HttpClient>();

        services.AddScoped<IAuthoriseService, AuthoriseService>();
    }
}
