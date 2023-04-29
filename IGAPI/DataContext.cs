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
    public DbSet<UserEntity> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateStatusEntity>().HasData(
            new CandidateStatusEntity
            {
                Id = 1,
                Name = "IN_PROGRESS"
            },
            new CandidateStatusEntity
            {
                Id = 2,
                Name = "PENDANT"
            },
            new CandidateStatusEntity
            {
                Id = 3,
                Name = "REJECTED"
            },
            new CandidateStatusEntity
            {
                Id = 4,
                Name = "HIRED"
            },
            new CandidateStatusEntity
            {
                Id = 5,
                Name = "DOUBT"
            }
        );
        modelBuilder.Entity<PositionStatusEntity>().HasData(
            new PositionStatusEntity
            {
                Id = 1,
                Name = "OPEN"
            },
            new PositionStatusEntity
            {
                Id = 2,
                Name = "CLOSED"
            },
            new PositionStatusEntity
            {
                Id = 3,
                Name = "IN_PROCESS"
            }
        );

    }
}