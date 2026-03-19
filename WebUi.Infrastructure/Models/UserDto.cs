using System.Text.Json.Serialization;
using WebUi.Infrastructure.Utils;

namespace WebUi.Infrastructure.Models;

public sealed record UserDto
{
    [JsonPropertyName(AuthStatics.LoginJsonName)]
    public required string Login { get; init; }

    [JsonPropertyName(AuthStatics.PasswordJsonName)]
    public required string Password { get; init; }
}
