using System.Net.Http.Json;
using WebUi.Infrastructure.Models;
using WebUi.Infrastructure.Services.Interfaces;

namespace WebUi.Infrastructure.Services;

public sealed class AuthoriseService(
    HttpClient httpClient,
    AstridsoftOptions settings) : IAuthoriseService
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private readonly AstridsoftOptions _settings = settings ?? throw new ArgumentNullException(nameof(settings));

    public async Task<string> AuthoriseAsync()
    {
        var response = await _httpClient.PostAsync(_settings.AuthoriseEndpoint,
            JsonContent.Create(_settings.UserAuth));

        // TODO Exception should be more specific
        return response.IsSuccessStatusCode
            // TODO Token not passed as string
            ? await response.Content.ReadAsStringAsync()
            : throw new InvalidOperationException();
    }
}
