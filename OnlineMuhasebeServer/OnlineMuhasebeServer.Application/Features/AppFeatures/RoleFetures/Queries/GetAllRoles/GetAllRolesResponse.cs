using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Queries.GetAllRoles;
public sealed class GetAllRolesResponse
{
    public IList<AppRole> Roles { get; set; }
}
