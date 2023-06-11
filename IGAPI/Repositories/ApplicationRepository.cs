
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class ApplicationRepository:Repository<ApplicationEntity>,IApplicationRepository
{
    public ApplicationRepository(DataContext dbContext) : base(dbContext)
    {
    }

    public override async Task<ApplicationEntity?> GetById(int id)
    {
        return await _dbSet.Where(entity => entity.Id == id)
            .Include(x => x.Candidate)
            .Include(x => x.Position)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public override async Task<IEnumerable<ApplicationEntity>> GetAll()
    {
        return await _dbSet
            .Include(x => x.Candidate)
            .Include(x => x.Position)
            .Include(x => x.Status)
            .ToListAsync();
    }
}