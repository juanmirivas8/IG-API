using System.Linq.Expressions;
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

    public IQueryable<T> GetQueryable()
    {
        return _dbSet;
    }
    
    public async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    

    public async Task<T> Add(T entity)
    {
        var et = await _dbSet.AddAsync(entity);
        return et.Entity;
    }

    public async Task<T> Update(T entity)
    {
        var et = _dbSet.Update(entity);
        return et.Entity;
    }

    public async Task<T> Delete(T entity)
    {
        return _dbSet.Remove(entity).Entity;
    }
    
    public async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<List<T>> GetByFilter(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.Where(filter).ToListAsync();
    }
}