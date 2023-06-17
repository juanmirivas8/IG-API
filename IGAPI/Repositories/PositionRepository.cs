using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class PositionRepository:Repository<PositionEntity>,IPositionRepository
{
    public PositionRepository(DataContext dbContext) : base(dbContext)
    {
    }

    public override async Task<PositionEntity?> GetById(int id)
    {
        return await _dbSet.Where(position => position.Id == id)
            .Include(position => position.Project)
            .Include(position =>position.Status)
            .Include(position => position.Area)
            .Include(position => position.Localization)
            .Include(position => position.Rol)
            .Include(position => position.SubRol)
            .Include(position => position.Applications)
                .ThenInclude(application => application.Status)
            .Include(position => position.Applications)
                .ThenInclude(application => application.Candidate)
            .FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<PositionEntity>> GetAll()
    {
        return await _dbSet
            .Include(position => position.Project)
            .Include(position => position.Status)
            .Include(position => position.Area)
            .Include(position => position.Localization)
            .Include(position => position.Rol)
            .Include(position => position.SubRol)
            .ToListAsync();
    }
}