using System.Net.Http.Headers;
using System.Net.Http.Json;
using WebUi.Infrastructure.Services.Interfaces;
using WebUi.Infrastructure.Utils;

namespace WebUi.Infrastructure.Services;

public sealed class AstridsoftDataCollector(
    string jwToken,
    Uri apiEndpoint,
    HttpClient client) : IDataCollector
{
    private readonly Uri _apiEndpoint = apiEndpoint ?? throw new ArgumentNullException(nameof(apiEndpoint));

    private readonly HttpClient _client = client ?? throw new ArgumentNullException(nameof(client));

    private readonly string _jwToken = string.IsNullOrWhiteSpace(jwToken)
        ? throw new ArgumentNullException(nameof(jwToken))
        : jwToken;

    public async Task<Dictionary<string, object>> CollectDataAsync()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, _apiEndpoint);
        // TODO Is it correct scheme
        request.Headers.Authorization = new AuthenticationHeaderValue(AuthStatics.BearerToken, _jwToken);

        var response = await _client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException();
        }

        var content = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();

        if (content is null)
        {
            throw new InvalidOperationException();
        }

        return content;
    }
}
