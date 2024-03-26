using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
public sealed record CreateRoleCommand(
    string Name,
    string Code) : ICommand<CreateRoleCommandResponse>;

