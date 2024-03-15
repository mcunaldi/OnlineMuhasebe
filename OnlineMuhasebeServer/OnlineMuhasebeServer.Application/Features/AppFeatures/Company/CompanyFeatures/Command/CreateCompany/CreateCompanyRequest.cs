using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.Company.CompanyFeatures.Command.CreateCompany;
public sealed record CreateCompanyRequest(
string Name,
string ServerName,
string DatabaseName,
string UserId,
string Password) : IRequest<CreateCompanyResponse>;
