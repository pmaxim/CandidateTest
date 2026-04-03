using MediatR;

namespace WebUi.Infrastructure.MediatorRequests;

public sealed record ApiEndpointUriRequest : IRequest<Uri>;
