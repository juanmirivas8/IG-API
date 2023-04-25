using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class ProjectRepository : Repository<ProjectEntity>, IProjectRepository
{
    public ProjectRepository(DataContext context) : base(context)
    {
    }

    public override async Task<List<ProjectEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public override async Task<ProjectEntity?> GetById(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
}
