using MediatR;
using WebUi.Infrastructure.MediatorRequests;

namespace WebUi.Infrastructure.Handlers.Interfaces;

public interface IAuthoriseHandler : IRequestHandler<AuthoriseRequest, string>;
