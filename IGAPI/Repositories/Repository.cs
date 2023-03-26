using System.Linq.Expressions;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected DbSet<T> _dbSet;
    protected readonly DataContext _context;
    
    public Repository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual IQueryable<T> GetQueryable()
    {
        return _dbSet;
    }
    
    public virtual async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    

    public virtual async Task<T> Add(T entity)
    {
        var et = await _dbSet.AddAsync(entity);
        return et.Entity;
    }

    public virtual async Task<T> Update(T entity)
    {
        var et = _dbSet.Update(entity);
        return et.Entity;
    }

    public virtual async Task<T> Delete(T entity)
    {
        return _dbSet.Remove(entity).Entity;
    }
    
    public virtual async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<List<T>> GetByFilter(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.Where(filter).ToListAsync();
    }
}