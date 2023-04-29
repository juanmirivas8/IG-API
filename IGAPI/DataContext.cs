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

        modelBuilder.Entity<ApplicationStatusEntity>().HasData(
            new ApplicationStatusEntity
            {
                Id = 1,
                Name = "SELECTED"
            },
            new ApplicationStatusEntity
            {
                Id = 2,
                Name = "REJECTED"
            },
            new ApplicationStatusEntity
            {
                Id = 3,
                Name = "DOUBT"
            }
        );

        modelBuilder.Entity<ContactMethodEntity>().HasData(
            new ContactMethodEntity
            {
                Id = 1,
                Name = "AGENCY"
            },
            new ContactMethodEntity
            {
                Id = 2,
                Name = "DIRECT"
            },
            new ContactMethodEntity
            {
                Id = 3,
                Name = "REFERRAL"
            }
        );

        modelBuilder.Entity<LocalizationEntity>().HasData(
            new LocalizationEntity
            {
                Id = 1,
                Name = "CORDOBA"
            },
            new LocalizationEntity
            {
                Id = 2,
                Name = "BARCELONA"
            },
            new LocalizationEntity
            {
                Id = 3,
                Name = "LONDON"
            }
        );

        modelBuilder.Entity<RolEntity>().HasData(
            new RolEntity
            {
                Id = 1,
                Name = "DEVELOPER"
            },
            new RolEntity
            {
                Id = 2,
                Name = "QA"
            }
        );

        modelBuilder.Entity<SubRolEntity>().HasData(
            new SubRolEntity
            {
                Id = 1,
                Name = "BACKEND"
            },
            new SubRolEntity
            {
                Id = 2,
                Name = "FRONTEND"
            }
        );

        modelBuilder.Entity<ProjectEntity>().HasData(
            new ProjectEntity
            {
                Id = 1,
                Name = "GATEWAY"
            },
            new ProjectEntity
            {
                Id = 2,
                Name = "BAU"
            }
        );

        modelBuilder.Entity<AreaEntity>().HasData(
            new AreaEntity
            {
                Id = 1,
                Name = "MOTOR"
            },
            new AreaEntity
            {
                Id = 2,
                Name = "FINANCES"
            }
        );
    }
}