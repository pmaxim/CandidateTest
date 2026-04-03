using MediatR;
using WebUi.Infrastructure.Models;

namespace WebUi.Infrastructure.MediatorRequests;

public sealed record AstridsoftOptionsRequest : IRequest<AstridsoftOptions>;
