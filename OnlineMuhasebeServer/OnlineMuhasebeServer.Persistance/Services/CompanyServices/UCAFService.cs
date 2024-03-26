using AutoMapper;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyServices;
public sealed class UCAFService(
    IUCAFCommandRepository commandRepository,
    IContextService contextService,
    CompanyDbContext context,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IUCAFService
{
    public async Task CreateUCAFAsync(CreateUCAFCommand request)
    {
        context = (CompanyDbContext)contextService.CreateDbContextInstance(request.CompanyId);
        commandRepository.SetDbContextInstance(context);
        unitOfWork.SetDbContextInstance(context);

        UniformChartOfAccount uniformChartOfAccount = mapper.Map<UniformChartOfAccount>(request);

        uniformChartOfAccount.Id = Guid.NewGuid().ToString();

        await commandRepository.AddAsync(uniformChartOfAccount);
        await unitOfWork.SaveChangesAsync();
    }
}
