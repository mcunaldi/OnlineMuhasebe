using MediatR;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
public sealed record CreateUCAFRequest(
    string Code,
    string Name,
    string Type,
    string CompanyId) : IRequest<CreateUCAFRequestResponse>;
