using MediatR;
using OnlineMuhasebeServer.Application.Services.AppService;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.Company.CompanyFeatures.Command.CreateCompany;
public sealed class CreateCompanyRequestHandler(ICompanyService companyService) : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        Domain.AppEntities.Company company = await companyService.GetCompanyByName(request.Name);

        if (company is not null)
        {
            throw new Exception("Bu şirket adı daha önce kullanılmış!");
        }

        await companyService.CreateCompany(request);
        return new();
    }
}
