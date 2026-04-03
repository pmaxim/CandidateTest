using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json;
using MediatR;
using Microsoft.VisualStudio.Threading;
using WebUi.Infrastructure.MediatorRequests;
using WebUi.Infrastructure.Services.Interfaces;

namespace WebUi.Infrastructure.Services;

public sealed class AuthoriseService : IAuthoriseService
{
    private const string TokenSection = "token";
    private const string TokenSectionNotFoundExceptionMessage = "The token section not found in the response";
    private readonly AsyncLazy<HttpRequest> _httpRequest;

    private readonly IMediator _mediator;

    public AuthoriseService(IMediator mediator,
        JoinableTaskContext joinableTaskContext)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(joinableTaskContext);

        _mediator = mediator;
        _httpRequest = new AsyncLazy<HttpRequest>(CreateHttpRequestFabric(mediator), joinableTaskContext.Factory);
    }

    public async Task<string> AuthoriseAndTakeTokenAsync()
    {
        var response = await _mediator.Send(await _httpRequest.GetValueAsync());

        response.EnsureSuccessStatusCode();

        var jsonDoc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());

        return jsonDoc.RootElement.GetProperty(TokenSection).GetString() ??
               throw new SerializationException(TokenSectionNotFoundExceptionMessage);
    }

    private static Func<Task<HttpRequest>> CreateHttpRequestFabric(ISender mediator)
    {
        return async () =>
        {
            var settings = await mediator.Send(new AstridsoftOptionsRequest());

            return new HttpRequest
            {
                RequestMessage = new HttpRequestMessage(HttpMethod.Post, settings.AuthoriseEndpoint)
                {
                    Content = JsonContent.Create(settings.UserAuth)
                }
            };
        };
    }
}
