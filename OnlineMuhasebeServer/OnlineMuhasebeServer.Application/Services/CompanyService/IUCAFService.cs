using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;

namespace OnlineMuhasebeServer.Application.Services.CompanyService;
public interface IUCAFService
{
    Task CreateUCAFAsync(CreateUCAFCommand request, CancellationToken cancellationToken);
}
