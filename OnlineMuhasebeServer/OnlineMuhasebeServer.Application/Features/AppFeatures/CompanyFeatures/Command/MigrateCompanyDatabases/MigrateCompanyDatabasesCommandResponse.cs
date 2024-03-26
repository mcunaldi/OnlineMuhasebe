namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.MigrateCompanyDatabases;
public sealed record MigrateCompanyDatabasesCommandResponse(
    string Message = "Şirketlerin database bilgileri migrate edildi.");