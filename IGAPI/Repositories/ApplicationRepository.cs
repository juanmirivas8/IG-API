
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class ApplicationRepository:Repository<ApplicationEntity>,IApplicationRepository
{
    public ApplicationRepository(DataContext dbContext) : base(dbContext)
    {
    }

    public override Task<ApplicationEntity?> GetById(int id)
    {
        return _dbSet.Where(entity => entity.Id == id)
            .Include(x => x.Candidate)
            .Include(x => x.Position)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}