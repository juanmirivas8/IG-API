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
        Console.WriteLine("ProjectRepository.GetAll()");
        return await _dbSet.Include(x=> x.Areas).ToListAsync();
    }
}
