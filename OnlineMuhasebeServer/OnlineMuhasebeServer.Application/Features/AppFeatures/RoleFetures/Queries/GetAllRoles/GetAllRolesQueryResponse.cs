using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Queries.GetAllRoles;
public sealed record GetAllRolesQueryResponse(
    IList<AppRole> Roles);