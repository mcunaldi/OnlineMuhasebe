using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.DeleteRole;
public sealed record DeleteRoleCommand(
    string Id) : ICommand<DeleteRoleCommandResponse>;
