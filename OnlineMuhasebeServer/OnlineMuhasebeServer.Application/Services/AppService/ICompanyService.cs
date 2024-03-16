using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppService;
public interface ICompanyService
{
    Task CreateCompany(CreateCompanyRequest request);
    Task MigrateCompanyDataBases(CancellationToken cancellation = default);
    Task<Company?> GetCompanyByName(string name); 
}
