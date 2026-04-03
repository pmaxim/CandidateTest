using MediatR;

namespace WebUi.Infrastructure.MediatorRequests;

public sealed record HttpRequest : IRequest<HttpResponseMessage>
{
    public required HttpRequestMessage RequestMessage { get; init; }
}
