using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance;
public sealed class ContextService(AppDbContext context) : IContextService
{
    public DbContext CreateDbContextInstance(string companyId)
    {
        Company company = context.Set<Company>().Find(companyId);
        return new CompanyDbContext(company);
    }
}
