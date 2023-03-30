using IGAPI.Models;
using IGAPI.Repositories.Interfaces;

namespace IGAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IProjectRepository ProjectRepository { get; }
    public UnitOfWork(IProjectRepository projectRepository, DataContext context)
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