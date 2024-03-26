using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
public sealed class CreateRoleHandle(IRoleService roleService) : ICommandHandler<CreateRoleCommand, CreateRoleCommandResponse>
{
    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        AppRole role = await roleService.GetByCode(request.Code);

        if (role != null)
        {
            throw new Exception("Bu rol daha önce kayıt edilmiş!");
        }

        await roleService.AddAsync(request);
        return new();
    }
}
