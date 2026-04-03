namespace WebUi.Core.Models;

public abstract record MarketType
{
    public required string Code { get; init; }

    public required string Name { get; init; }

    public required string Category { get; init; }

    public int DisplayOrder { get; init; }

    public string Description { get; init; } = string.Empty;
}
