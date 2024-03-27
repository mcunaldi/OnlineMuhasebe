using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
public sealed class CreateCompanyCommandHandler(ICompanyService companyService) : ICommandHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
{
    public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Domain.AppEntities.Company company = await companyService.GetCompanyByName(request.Name);

        if (company is not null)
        {
            throw new Exception("Bu şirket adı daha önce kullanılmış!");
        }

        await companyService.CreateCompany(request, cancellationToken);
        return new();
    }
}
