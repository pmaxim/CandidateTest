using MediatR;
using WebUi.Infrastructure.MediatorRequests;

namespace WebUi.Infrastructure.Handlers.Interfaces;

public interface IHttpClientHandler : IRequestHandler<HttpRequest, HttpResponseMessage>;
