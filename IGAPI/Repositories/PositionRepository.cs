using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class PositionRepository:Repository<PositionEntity>,IPositionRepository
{
    public PositionRepository(DataContext dbContext) : base(dbContext)
    {
    }
}