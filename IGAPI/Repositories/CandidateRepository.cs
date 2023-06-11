using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IGAPI.Repositories;

public class CandidateRepository:Repository<CandidateEntity>,ICandidateRepository
{
   public CandidateRepository(DataContext dbContext) : base(dbContext)
   {
   }
   
   public override Task<CandidateEntity?> GetById(int id)
   {
      return _dbSet.Where(entity => entity.Id == id)
         .Include(x => x.Applications)
         .Include(x => x.Status)
         .Include(x => x.ContactMethod)
         .FirstOrDefaultAsync(x => x.Id == id);
   }
}