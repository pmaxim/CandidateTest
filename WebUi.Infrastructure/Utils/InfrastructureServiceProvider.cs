using Microsoft.Extensions.DependencyInjection;
using WebUi.Infrastructure.Enums;
using WebUi.Infrastructure.Models;
using WebUi.Infrastructure.Services;
using WebUi.Infrastructure.Services.Interfaces;

namespace WebUi.Infrastructure.Utils;

public static class InfrastructureServiceProvider
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<HttpClient>();
        // TODO Must be compatible with lazy
        // TODO note, it's bearer-token
        services.AddKeyedScoped<Task<string>>(DiKeys.AstridsoftJwToken,
            // TODO What is the second passed object
            static (provider, _) =>
            {
                var service = provider.GetRequiredService<IAuthoriseService>();

                return service.AuthoriseAsync();
            });
        services.AddOptions<AstridsoftOptions>();

        services.AddScoped<IAuthoriseService, AuthoriseService>();
        services.AddScoped<IDataCollector, AstridsoftDataCollector>();
    }
}
