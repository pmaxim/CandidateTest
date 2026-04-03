namespace WebUi.Core.Models;

public abstract record Provider
{
    public required string Name { get; init; }

    public required string Trademark { get; init; }

    public required Uri ApiBaseUrl { get; init; }

    public required string ProviderType { get; init; }

    public required Uri AvatarUrlTemplate { get; init; }

    public required Uri TeamLogoUrlTemplate { get; init; }

    public byte[] AvailableImageSizes { get; init; } = [];

    public byte[] Sports { get; init; } = [];
}
