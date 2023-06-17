using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class CandidateRepository:Repository<CandidateEntity>,ICandidateRepository
{
   public CandidateRepository(DataContext dbContext) : base(dbContext)
   {
   }
   
   public override async Task<CandidateEntity?> GetById(int id)
   {
      return await _dbSet.Where(entity => entity.Id == id)
         .Include(x => x.Applications)
            .ThenInclude(application => application.Status)
         .Include(x => x.Applications)
            .ThenInclude(application => application.Position)
         .Include(x => x.Status)
         .Include(x => x.ContactMethod)
         .FirstOrDefaultAsync(x => x.Id == id);
   }
   
   public override async Task<IEnumerable<CandidateEntity>> GetAll()
   {
      return await _dbSet
         .Include(x => x.Applications)
         .Include(x => x.Status)
         .Include(x => x.ContactMethod)
         .ToListAsync();
   }
}