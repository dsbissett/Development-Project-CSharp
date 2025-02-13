﻿using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Sparcpoint.Inventory.Abstractions;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
{
    private readonly DbContext context;

    protected RepositoryBase(DbContext context)
    {
        this.context = context;
    }

    public IQueryable<T> GetAll() => this.context.Set<T>();

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await this.context.Set<T>().ToListAsync();

    public virtual T? Get(int id) => this.context.Set<T>().Find(id);

    public virtual async Task<T?> GetAsync(int id) => await this.context.Set<T>().FindAsync(id);

    public virtual T Add([NotNull] T t)
    {
        this.context.Set<T>().Add(t);
        this.context.SaveChanges();
        return t;
    }

    public virtual async Task<T> AddAsync([NotNull] T t)
    {
        await this.context.Set<T>().AddAsync(t);
        await this.context.SaveChangesAsync();
        return t;
    }

    public virtual T? Find(Expression<Func<T, bool>> expr)
    {
        return this.context.Set<T>().SingleOrDefault(expr);
    }

    public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expr)
    {
        return await this.context.Set<T>().Where(expr).ToListAsync();
    }

    public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> expr)
    {
        return this.context.Set<T>().Where(expr);
    }

    public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> expr)
    {
        return await this.context.Set<T>().Where(expr).ToListAsync();
    }

    public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
        var queryable = this.GetAll();

        return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
    }

    public virtual T? Update([NotNull] T t)
    {
        var keyName = this.context.Model
            .FindEntityType(typeof(T))
            ?.FindPrimaryKey()
            ?.Properties
            .Select(x => x.Name).Single();

        var key = typeof(T).GetProperty(keyName)?.GetValue(t, null);

        var entity = this.context.Set<T>().Find(key);

        if (entity == null) return entity;

        var entry = this.context.Entry(entity);

        entry.CurrentValues.SetValues(t);

        foreach (var property in entry.Properties)
        {
            if (property.CurrentValue != null) continue;

            property.IsModified = property.OriginalValue != null && property.OriginalValue == property.CurrentValue;
        }

        this.context.SaveChanges();

        return entity;
    }

    public virtual async Task<T?> UpdateAsync([NotNull] T t)
    {
        var keyName = this.context.Model
            .FindEntityType(typeof(T))
            ?.FindPrimaryKey()
            ?.Properties
            .Select(x => x.Name).Single();

        var key = typeof(T).GetProperty(keyName)?.GetValue(t, null);

        var entity = await this.context.Set<T>().FindAsync(key);

        if (entity == null) return entity;

        var entry = this.context.Entry(entity);

        entry.CurrentValues.SetValues(t);

        foreach (var property in entry.Properties)
        {
            if (property.CurrentValue != null) continue;

            property.IsModified = property.OriginalValue != null && property.OriginalValue == property.CurrentValue;
        }
        
        await this.context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> expr)
    {
        return await this.context.Set<T>().SingleOrDefaultAsync(expr);
    }

    public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> expr)
    {
        return this.context.Set<T>().Where(expr).ToList();
    }
}