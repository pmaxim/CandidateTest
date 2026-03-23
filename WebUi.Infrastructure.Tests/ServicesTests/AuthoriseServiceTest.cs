using Microsoft.Extensions.Configuration;
using WebUi.Infrastructure.Models;
using WebUi.Infrastructure.Services;
using WebUi.Infrastructure.Tests.Utils;

namespace WebUi.Infrastructure.Tests.ServicesTests;

[TestClass]
public sealed class AuthoriseServiceTest : IDisposable
{
    private static readonly AstridsoftOptions AstridsoftOptions = CredsExtractor.Extract(new ConfigurationBuilder()
        .AddUserSecrets<AuthoriseServiceTest>()
        .Build());

    private readonly AuthoriseService _authoriseService = new(new HttpClient(), AstridsoftOptions);
    private bool _disposed;

    [TestMethod]
    public async Task AuthoriseAsyncTest()
    {
        var token = await _authoriseService.AuthoriseAsync();

        Assert.IsFalse(string.IsNullOrWhiteSpace(token));
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
            _authoriseService.Dispose();
        }

        _disposed = true;
    }

    ~AuthoriseServiceTest()
    {
        Dispose(false);
    }
}
