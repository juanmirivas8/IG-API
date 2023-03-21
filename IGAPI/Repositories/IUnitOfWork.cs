using IGAPI.Models;

namespace IGAPI.Repositories;

public interface IUnitOfWork
{ 
    IRepository<ProjectEntity> ProjectRepository { get; }
    Task<int> SaveChangesAsync();
    void Dispose();
}