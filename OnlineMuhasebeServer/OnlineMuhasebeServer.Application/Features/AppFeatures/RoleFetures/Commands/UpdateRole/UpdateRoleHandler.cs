using MediatR;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.UpdateRole;
public sealed class UpdateRoleHandler(IRoleService roleService) : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
{
    public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        AppRole role = await roleService.GetById(request.Id);
        if (role == null)
        {
            throw new Exception("Role bulunamadı!");
        }

        if (role.Code != request.Code)
        {
            AppRole checkCode = await roleService.GetByCode(request.Code);
            if (checkCode != null)
            {
                throw new Exception("Bu kod daha önce kaydedilmiş!");
            }

        }
        role.Code = request.Code;
        role.Name = request.Name;
        await roleService.UpdateAsync(role);
        return new();
    }
}
