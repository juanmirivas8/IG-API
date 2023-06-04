using System.Linq.Expressions;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;

namespace IGAPI.Repositories;

public class CandidateRepository:Repository<CandidateEntity>,ICandidateRepository
{
   public CandidateRepository(DataContext dbContext) : base(dbContext)
   {
   }
}