using MediatR;
using OnlineMuhasebeServer.Application.Services.CompanyService;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
internal class CreateUCAFRequestHandler(IUCAFService uCAFService) : IRequestHandler<CreateUCAFRequest, CreateUCAFRequestResponse>
{
    public async Task<CreateUCAFRequestResponse> Handle(CreateUCAFRequest request, CancellationToken cancellationToken)
    {
        await uCAFService.CreateUCAFAsync(request);
        return new();
    }
}
