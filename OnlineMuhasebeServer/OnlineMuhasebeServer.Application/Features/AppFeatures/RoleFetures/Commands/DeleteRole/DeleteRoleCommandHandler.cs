using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.hRoleFetures.Commands.DeleteRole;
public sealed class DeleteRoleCommandHandler(IRoleService roleService) : ICommandHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
{
    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        AppRole role = await roleService.GetById(request.Id);
        if (role == null)
        {
            throw new Exception("Role bulunamadı!");
        }

        await roleService.DeleteAsync(role);
        return new();
    }
}
