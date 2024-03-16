using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Context;
using System;

namespace OnlineMuhasebeServer.Persistance.Repositories;
public class QueryRepository<T> : IQueryRepository<T>
    where T : Entity
{
    private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled =
        EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
        context.Set<T>().FirstOrDefault(p => p.Id == id));

    private static readonly Func<CompanyDbContext, Task<T>> GetFirstCompiled =
        EF.CompileAsyncQuery((CompanyDbContext context) =>
        context.Set<T>().FirstOrDefault());

    private static readonly Func<CompanyDbContext, System.Linq.Expressions.Expression<Func<T, bool>>, Task<T>> GetFirstByExpressionCompiled =
        EF.CompileAsyncQuery((CompanyDbContext context, System.Linq.Expressions.Expression<Func<T, bool>> predicate) =>
        context.Set<T>().FirstOrDefault(predicate));

    private CompanyDbContext _context;
    public DbSet<T> Entity { get; set; }

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        Entity = context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return Entity.AsQueryable();
    }

    public async Task<T> GetById(string id)
    {
        return await GetFirstCompiled(_context);
    }

    public Task<T> GetFirst()
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetFirstByExpression(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return await GetFirstByExpressionCompiled(_context, predicate);
    }

    public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return Entity.Where(predicate);
    }
}
