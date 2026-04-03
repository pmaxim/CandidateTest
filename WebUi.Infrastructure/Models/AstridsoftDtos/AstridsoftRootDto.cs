namespace WebUi.Infrastructure.Models.AstridsoftDtos;

public sealed record AstridsoftRootDto
{
    public MarketGroupDto? MarketGroup { get; init; }

    public MarketTypeDto? MarketType { get; init; }

    public RoundDto? Round { get; init; }

    public PeriodDto? Period { get; init; }

    public ProviderDto? Provider { get; init; }
}
