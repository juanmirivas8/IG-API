using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class PositionRepository:Repository<PositionEntity>,IPositionRepository
{
    public PositionRepository(DataContext dbContext) : base(dbContext)
    {
    }

    public override Task<PositionEntity?> GetById(int id)
    {
        return _dbSet.Where(position => position.Id == id)
            .Include(position => position.Project)
            .Include(position =>position.Status)
            .Include(position => position.Area)
            .Include(position => position.Localization)
            .Include(position => position.Rol)
            .Include(position => position.SubRol)
            .Include(position => position.Applications)
            .FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<PositionEntity>> GetAll()
    {
        return _dbSet
            .Include(position => position.Project)
            .Include(position => position.Status)
            .Include(position => position.Area)
            .Include(position => position.Localization)
            .Include(position => position.Rol)
            .Include(position => position.SubRol);
    }
}