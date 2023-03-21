using IGAPI.Models;

namespace IGAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IRepository<ProjectEntity> ProjectRepository { get; }
    public UnitOfWork(IRepository<ProjectEntity> projectRepository, DataContext context)
    {
        ProjectRepository = projectRepository;
        _context = context;
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}