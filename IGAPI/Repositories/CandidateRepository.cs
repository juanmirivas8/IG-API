using System.Linq.Expressions;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;

namespace IGAPI.Repositories;

public class CandidateRepository:ICandidateRepository
{
    public IQueryable<CandidateEntity> GetQueryable()
    {
        throw new NotImplementedException();
    }

    public async Task<CandidateEntity?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CandidateEntity> Add(CandidateEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<CandidateEntity> Update(CandidateEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<CandidateEntity> Delete(CandidateEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CandidateEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CandidateEntity>> GetByFilter(Expression<Func<CandidateEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }
}