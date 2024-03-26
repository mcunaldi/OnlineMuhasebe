using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
public sealed record CreateCompanyCommand(
string Name,
string ServerName,
string DatabaseName,
string UserId,
string Password) : ICommand<CreateCompanyCommandResponse>;
