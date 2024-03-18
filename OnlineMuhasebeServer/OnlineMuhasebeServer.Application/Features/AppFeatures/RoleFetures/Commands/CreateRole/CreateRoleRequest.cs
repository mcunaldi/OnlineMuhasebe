using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
public sealed record CreateRoleRequest(
    string Name,
    string Code) : IRequest<CreateRoleResponse>;

