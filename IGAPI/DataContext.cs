using IGAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IGAPI;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options) { }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<AreaEntity> Areas { get; set; }
    public DbSet<ApplicationEntity> Applications { get; set; }
    public DbSet<ApplicationStatusEntity> ApplicationStatus { get; set; }
    public DbSet<CandidateEntity> Candidates { get; set; }
    public DbSet<CandidateStatusEntity> CandidateStatus { get; set; }
    public DbSet<LocalizationEntity> Localizations { get; set; }
    public DbSet<PositionEntity> Positions { get; set; }
    public DbSet<PositionStatusEntity> PositionStatus { get; set; }
    public DbSet<RolEntity> Roles { get; set; }
    public DbSet<SubRolEntity> SubRoles { get; set; }

    
}