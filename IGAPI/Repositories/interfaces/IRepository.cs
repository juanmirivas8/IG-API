
using System.Linq.Expressions;

namespace IGAPI.Repositories.Interfaces;

public interface IRepository<T> where T:class
{
    IQueryable<T> GetQueryable();
    Task<T?> GetById(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
    Task<IEnumerable<T>> GetAll();
    
    Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> filter);
}