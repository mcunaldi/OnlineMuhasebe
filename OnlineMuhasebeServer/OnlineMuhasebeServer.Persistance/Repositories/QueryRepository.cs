﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;
using OnlineMuhasebeServer.Persistance.Context;
using System;

namespace OnlineMuhasebeServer.Persistance.Repositories;
public class QueryRepository<T> : IQueryRepository<T>
    where T : Entity
{
    private static readonly Func<CompanyDbContext, string, bool, Task<T>> GetByIdCompiled =
        EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) =>
        isTracking == true 
        ? context.Set<T>().FirstOrDefault(p => p.Id == id) 
        : context.Set<T>().AsQueryable().FirstOrDefault(p => p.Id == id));

    private static readonly Func<CompanyDbContext, bool, Task<T>> GetFirstCompiled =
        EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
        isTracking == true
        ? context.Set<T>().FirstOrDefault()
        : context.Set<T>().AsQueryable().FirstOrDefault());

    private static readonly Func<CompanyDbContext, System.Linq.Expressions.Expression<Func<T, bool>>, bool, Task<T>> GetFirstByExpressionCompiled =
        EF.CompileAsyncQuery((CompanyDbContext context, System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool isTracking) =>
        isTracking == true
        ? context.Set<T>().FirstOrDefault(predicate)
        : context.Set<T>().AsNoTracking().FirstOrDefault(predicate));

    private CompanyDbContext _context;
    public DbSet<T> Entity { get; set; }

    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        Entity = context.Set<T>();
    }

    public IQueryable<T> GetAll(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if(!isTracking)
            result = result.AsQueryable();
        return Entity.AsQueryable();
    }

    public async Task<T> GetById(string id, bool isTracking)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public Task<T> GetFirst(bool isTracking)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetFirstByExpression(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool isTracking = true)
    {
        return await GetFirstByExpressionCompiled(_context, predicate, isTracking);
    }

    public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool isTracking = true)
    {
        var result = Entity.Where(predicate);
        if (!isTracking)
        {
            result = result.AsQueryable();
        }

        return result;
    }
}
