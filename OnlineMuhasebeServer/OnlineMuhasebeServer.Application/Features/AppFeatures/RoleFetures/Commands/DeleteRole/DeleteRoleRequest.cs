using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.DeleteRole;
public sealed record DeleteRoleRequest(
    string Id) : IRequest<DeleteRoleResponse>;
