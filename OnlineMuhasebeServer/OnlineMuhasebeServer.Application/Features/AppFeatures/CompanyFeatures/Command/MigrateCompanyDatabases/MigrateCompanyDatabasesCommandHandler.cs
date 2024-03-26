using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.MigrateCompanyDatabases;
public sealed class MigrateCompanyDatabasesCommandHandler(
    ICompanyService companyService) : ICommandHandler<MigrateCompanyDatabasesCommand, MigrateCompanyDatabasesCommandResponse>
{
    public async Task<MigrateCompanyDatabasesCommandResponse> Handle(MigrateCompanyDatabasesCommand request, CancellationToken cancellationToken)
    {
        await companyService.MigrateCompanyDataBases();
        return new();
    }
}
