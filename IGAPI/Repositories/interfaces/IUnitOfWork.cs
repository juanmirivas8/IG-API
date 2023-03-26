using IGAPI.Models;

namespace IGAPI.Repositories.Interfaces;

public interface IUnitOfWork
{ 
    IRepository<ProjectEntity> ProjectRepository { get; }
    Task<int> SaveChangesAsync();
    void Dispose();
}