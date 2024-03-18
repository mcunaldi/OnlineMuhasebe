using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Queries.GetAllRoles;
public sealed record GetAllRolesRequest : IRequest<GetAllRolesResponse>;
