using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class PositionRepository:Repository<PositionEntity>,IPositionRepository
{
    public PositionRepository(DataContext dbContext) : base(dbContext)
    {
    }
    
    
    override public async Task<PositionEntity?> GetById(int positionId)
    {
        PositionEntity position = _dbSet
            .Include(p => p.Project)
            .Include(p => p.Area)
            .Include(p => p.Rol)
            .Include(p => p.SubRol)
            .Include(p => p.Localization)
            .Include(p => p.Status)
            .Include(p => p.Applications)
            .ThenInclude(a => a.Candidate)
            .FirstOrDefault(p => p.Id == positionId);

        // Exclude the Applications lists of the Candidate and Position within each Application
        foreach (var application in position.Applications)
        {
            application.Candidate.Applications = null;
        }

        return position;
    }
}