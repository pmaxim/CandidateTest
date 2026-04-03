using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebUi.Database.Context;

namespace WebUi.Database.Utils;

public static class DataBaseProvider
{
    private const string ConnectionStringName = "DefaultConnection";

    public static void AddDatabase(this IServiceCollection services, IConfiguration configs)
    {
        services.AddDbContext<AstridsoftDbContext>(options =>
            options.UseSqlServer(configs.GetConnectionString(ConnectionStringName)));
    }
}
