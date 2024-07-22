// <copyright file="RepositoryBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using AdvancedAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAPI.Data.Repositories;

/// <summary>
/// base repository
/// </summary>
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AdvancedApiContext _context;
    private readonly DbSet<T> _dbSet;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BaseRepository(AdvancedApiContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<T> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    /// <inheritdoc />
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    /// <inheritdoc />
    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    /// <inheritdoc />
    public void Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    /// <inheritdoc />
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
