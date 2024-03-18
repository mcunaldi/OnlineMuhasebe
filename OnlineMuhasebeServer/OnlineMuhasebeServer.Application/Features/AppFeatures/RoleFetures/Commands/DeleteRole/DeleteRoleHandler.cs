using MediatR;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.hRoleFetures.Commands.DeleteRole;
public sealed class DeleteRoleHandler(IRoleService roleService) : IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
{
    public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
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
