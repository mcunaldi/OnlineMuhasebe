using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.UpdateRole;
public sealed record UpdateRoleRequest(
    string Id,
    string Code,
    string Name) : IRequest<UpdateRoleResponse>;