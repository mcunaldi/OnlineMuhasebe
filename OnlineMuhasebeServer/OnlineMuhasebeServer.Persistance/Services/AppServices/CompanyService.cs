using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices;
public sealed class CompanyService(
    AppDbContext context,
    IMapper mapper) : ICompanyService
{
    private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled =
        EF.CompileAsyncQuery((AppDbContext context, string name) =>
        context.Set<Company>().FirstOrDefault(p => p.Name == name)); 
    
    //daha performanslı olduğundan dolayı kullanıldı.
    //await context.Set<Company>().FirstOrDefault(p=> p.Name == name) de kullanılabilirdi!!

    public async Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = mapper.Map<Company>(request);
        company.Id = Guid.NewGuid().ToString();
        await context.Set<Company>().AddAsync(company, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Company?> GetCompanyByName(string name)
    {
        return await GetCompanyByNameCompiled(context, name);
    }

    public async Task MigrateCompanyDataBases()
    {
        var companies = await context.Set<Company>().ToListAsync();
        foreach (var company in companies)
        {
            var db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}
