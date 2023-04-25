using IGAPI.Models;

namespace IGAPI.Repositories.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    void Dispose();
}