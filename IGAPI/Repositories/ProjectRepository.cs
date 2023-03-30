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
        return await _dbSet.Include(x=> x.Areas).ToListAsync();
    }

    public override async Task<ProjectEntity?> GetById(int id)
    {
        return await _dbSet.Include(x=> x.Areas).FirstOrDefaultAsync(x => x.Id == id);
    }
}
