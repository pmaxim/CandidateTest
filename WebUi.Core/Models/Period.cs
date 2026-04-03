namespace WebUi.Core.Models;

public abstract record Period
{
    public required string Code { get; init; }

    public required string Name { get; init; }

    public byte[] Sports { get; init; } = [];
}
