using System.Linq.Expressions;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;

namespace IGAPI.Repositories;

public class ApplicationRepository:Repository<ApplicationEntity>,IApplicationRepository
{
    public ApplicationRepository(DataContext dbContext) : base(dbContext)
    {
    }
}