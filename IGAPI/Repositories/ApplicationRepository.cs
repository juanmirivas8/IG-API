using System.Linq.Expressions;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;

namespace IGAPI.Repositories;

public class ApplicationRepository:IApplicationRepository
{
    public IQueryable<ApplicationEntity> GetQueryable()
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationEntity?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationEntity> Add(ApplicationEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationEntity> Update(ApplicationEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationEntity> Delete(ApplicationEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ApplicationEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ApplicationEntity>> GetByFilter(Expression<Func<ApplicationEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }
}