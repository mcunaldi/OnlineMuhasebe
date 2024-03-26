using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Queries.GetAllRoles;
public sealed class GetAllRolesQueryHandler(
    IRoleService roleService) : IQueryHandler<GetAllRolesQuery, GetAllRolesQueryResponse>
{
    public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        IList<AppRole> roles = await roleService.GetAllRolesAsync();
        return new GetAllRolesQueryResponse(
            Roles : roles);
    }
}
