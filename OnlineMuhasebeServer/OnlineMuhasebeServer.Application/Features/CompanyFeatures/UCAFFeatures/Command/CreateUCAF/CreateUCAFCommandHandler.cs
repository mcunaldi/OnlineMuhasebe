using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
internal class CreateUCAFCommandHandler(IUCAFService uCAFService) : ICommandHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
{
    public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
    {
        await uCAFService.CreateUCAFAsync(request, cancellationToken);
        return new();
    }
}
