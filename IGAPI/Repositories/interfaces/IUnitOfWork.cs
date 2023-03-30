using IGAPI.Models;

namespace IGAPI.Repositories.Interfaces;

public interface IUnitOfWork
{ 
    IProjectRepository ProjectRepository { get; }
    Task<int> SaveChangesAsync();
    void Dispose();
}