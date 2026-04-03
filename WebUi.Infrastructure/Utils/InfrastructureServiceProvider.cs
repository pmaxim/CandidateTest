using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using WebUi.Infrastructure.Models;
using WebUi.Infrastructure.Services;
using WebUi.Infrastructure.Services.Interfaces;

namespace WebUi.Infrastructure.Utils;

public static class InfrastructureServiceProvider
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<HttpClient>();
        services.AddScoped<IAuthoriseService, AuthoriseService>();
        services.AddScoped<IDataCollector, AstridsoftDataCollector>();

        services.AddOptions<AstridsoftOptions>();

        services.AddMediatR(static cfg =>
            cfg.RegisterServicesFromAssembly(typeof(InfrastructureServiceProvider).GetTypeInfo().Assembly));
    }
}
