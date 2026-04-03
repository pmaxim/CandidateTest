using WebUi.Infrastructure.Handlers.Interfaces;
using WebUi.Infrastructure.MediatorRequests;
using WebUi.Infrastructure.Services.Interfaces;

namespace WebUi.Infrastructure.Handlers;

public sealed class AuthoriseHandler(IAuthoriseService authoriseService) : IAuthoriseHandler
{
    private readonly IAuthoriseService _authoriseService =
        authoriseService ?? throw new ArgumentNullException(nameof(authoriseService));

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public Task<string> Handle(AuthoriseRequest request, CancellationToken cancellationToken)
    {
        return _authoriseService.AuthoriseAndTakeTokenAsync();
    }
}
