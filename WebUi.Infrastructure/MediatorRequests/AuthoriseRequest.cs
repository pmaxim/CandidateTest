using MediatR;

namespace WebUi.Infrastructure.MediatorRequests;

public sealed record AuthoriseRequest : IRequest<string>;
