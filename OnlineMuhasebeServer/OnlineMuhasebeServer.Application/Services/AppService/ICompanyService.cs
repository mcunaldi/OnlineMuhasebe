using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppService;
public interface ICompanyService
{
    Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken);
    Task MigrateCompanyDataBases();
    Task<Company?> GetCompanyByName(string name); 
}
