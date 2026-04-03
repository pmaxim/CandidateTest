using System.Net.Http.Headers;
using System.Net.Http.Json;
using MediatR;
using Microsoft.VisualStudio.Threading;
using WebUi.Infrastructure.MediatorRequests;
using WebUi.Infrastructure.Models.AstridsoftDtos;
using WebUi.Infrastructure.Services.Interfaces;
using WebUi.Infrastructure.Utils;

namespace WebUi.Infrastructure.Services;

public sealed class AstridsoftDataCollector : IDataCollector
{
    private static readonly ApiEndpointUriRequest ApiEndpointUriRequest = new();
    private readonly AsyncLazy<HttpRequest> _httpRequestMessageTemplate;
    private readonly IMediator _mediator;

    public AstridsoftDataCollector(IMediator mediator, JoinableTaskContext joinableTaskContext)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(joinableTaskContext);

        _mediator = mediator;
        _httpRequestMessageTemplate =
            new AsyncLazy<HttpRequest>(CreateHttpRequestFabric(_mediator), joinableTaskContext.Factory);
    }

    public async Task<AstridsoftRootDto> CollectDataAsync()
    {
        var response = await _mediator.Send(await _httpRequestMessageTemplate.GetValueAsync());

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<AstridsoftRootDto>();

        return content ?? throw new InvalidOperationException();
    }

    private static Func<Task<HttpRequest>> CreateHttpRequestFabric(ISender mediator)
    {
        return async () =>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, await mediator.Send(ApiEndpointUriRequest));

            request.Headers.Authorization = new AuthenticationHeaderValue(
                AuthStatics.BearerToken,
                await mediator.Send(new AuthoriseRequest()));

            return new HttpRequest
            {
                RequestMessage = request
            };
        };
    }
}
