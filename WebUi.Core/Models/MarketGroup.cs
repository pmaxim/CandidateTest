namespace WebUi.Core.Models;

public abstract record MarketGroup
{
    public required string Code { get; init; }

    public required string Name { get; init; }

    public int DisplayOrder { get; init; }
}
