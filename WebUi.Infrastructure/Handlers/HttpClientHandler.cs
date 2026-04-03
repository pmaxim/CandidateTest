using WebUi.Infrastructure.Handlers.Interfaces;
using WebUi.Infrastructure.MediatorRequests;

namespace WebUi.Infrastructure.Handlers;

public sealed class HttpClientHandler(HttpClient client) : IHttpClientHandler, IDisposable
{
    private readonly HttpClient _client = client ?? throw new ArgumentNullException(nameof(client));
    private bool _disposed;

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task<HttpResponseMessage> Handle(HttpRequest request, CancellationToken cancellationToken)
    {
        return _client.SendAsync(request.RequestMessage, cancellationToken);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _client.Dispose();
        }

        _disposed = true;
    }

    ~HttpClientHandler()
    {
        Dispose(false);
    }
}
