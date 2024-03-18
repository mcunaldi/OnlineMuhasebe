using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices;
public sealed class RoleService(
    RoleManager<AppRole> roleManager,
    IMapper mapper) : IRoleService
{
    public async Task AddAsync(CreateRoleRequest request)
    {
        AppRole role = mapper.Map<AppRole>(request);
        role.Id = Guid.NewGuid().ToString();
        await roleManager.CreateAsync(role);
    }

    public async Task DeleteAsync(AppRole appRole)
    {
        await roleManager.DeleteAsync(appRole);
    }

    public async Task<IList<AppRole>> GetAllRolesAsync()
    {
        IList<AppRole> roles = await roleManager.Roles.ToListAsync();
        return roles;
    }

    public async Task<AppRole> GetByCode(string code)
    {
        AppRole role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Code == code);
        return role;
    }

    public async Task<AppRole> GetById(string id)
    {
        AppRole role = await roleManager.FindByIdAsync(id);
        return role;
    }

    public async Task UpdateAsync(AppRole appRole)
    {
        await roleManager.UpdateAsync(appRole);
    }
}
