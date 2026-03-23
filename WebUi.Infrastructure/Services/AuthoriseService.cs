using System.Net.Http.Json;
using System.Text.Json;
using WebUi.Infrastructure.Models;
using WebUi.Infrastructure.Services.Interfaces;

namespace WebUi.Infrastructure.Services;

public sealed class AuthoriseService(
    HttpClient httpClient,
    AstridsoftOptions settings) : IAuthoriseService, IDisposable
{
    private const string TokenSection = "token";

    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private readonly AstridsoftOptions _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    private bool _disposed;

    public async Task<string> AuthoriseAsync()
    {
        var response = await _httpClient.PostAsync(_settings.AuthoriseEndpoint,
            JsonContent.Create(_settings.UserAuth));

        if (!response.IsSuccessStatusCode)
        {
            // TODO Exception should be more specific
            throw new InvalidOperationException();
        }

        var jsonDoc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
        // TODO Exception should be more specific
        return jsonDoc.RootElement.GetProperty(TokenSection).GetString() ?? throw new InvalidOperationException();
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _httpClient.Dispose();
        }

        _disposed = true;
    }

    ~AuthoriseService()
    {
        Dispose(false);
    }
}
