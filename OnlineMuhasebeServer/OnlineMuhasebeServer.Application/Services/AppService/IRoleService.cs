using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.UpdateRole;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Services.AppService;
public interface IRoleService
{
    Task AddAsync(CreateRoleCommand request);
    Task UpdateAsync(AppRole appRole);
    Task DeleteAsync(AppRole appRole);
    Task<IList<AppRole>> GetAllRolesAsync();
    Task<AppRole> GetById(string id);
    Task<AppRole> GetByCode(string code);
}
