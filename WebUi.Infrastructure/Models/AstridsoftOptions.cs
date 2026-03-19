using System.Text.Json.Serialization;
using WebUi.Infrastructure.Utils;

namespace WebUi.Infrastructure.Models;

public sealed record AstridsoftOptions
{
    [JsonPropertyName(AuthStatics.AuthoriseEndpointJsonName)]
    public required Uri AuthoriseEndpoint { get; init; }

    [JsonPropertyName(AuthStatics.UserAuthJsonName)]
    public required UserDto UserAuth { get; init; }
}
