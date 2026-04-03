using Microsoft.EntityFrameworkCore;
using WebUi.Database.Entities;

namespace WebUi.Database.Context;

public sealed class AstridsoftDbContext : DbContext
{
    public DbSet<ProviderEntity> Providers { get; init; }

    public DbSet<RoundEntity> Rounds { get; init; }

    public DbSet<PeriodEntity> Periods { get; init; }

    public DbSet<MarketGroupEntity> MarketGroups { get; init; }

    public DbSet<MarketTypeEntity> MarketTypes { get; init; }
}
