﻿using MediatR;
using OnlineMuhasebeServer.Application.Services.AppService;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.Company.CompanyFeatures.Command.MigrateCompanyDatabase;
public sealed class MigrateCompanyDatabasesHandler(
    ICompanyService companyService) : IRequestHandler<MigrateCompanyDatabasesRequest, MigrateCompanyDatabasesResponse>
{
    public async Task<MigrateCompanyDatabasesResponse> Handle(MigrateCompanyDatabasesRequest request, CancellationToken cancellationToken)
    {
        await companyService.MigrateCompanyDataBases();
        return new();
    }
}
