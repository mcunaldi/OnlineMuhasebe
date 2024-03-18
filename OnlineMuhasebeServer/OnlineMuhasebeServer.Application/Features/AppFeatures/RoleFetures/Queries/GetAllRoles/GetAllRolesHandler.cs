using MediatR;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Queries.GetAllRoles;
public sealed class GetAllRolesHandler(
    IRoleService roleService) : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
{
    public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
    {
        IList<AppRole> roles = await roleService.GetAllRolesAsync();
        return new GetAllRolesResponse { Roles = roles };
    }
}
