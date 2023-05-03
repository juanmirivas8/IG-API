using IGAPI.Models;

namespace IGAPI.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRepository<LocalizationEntity> LocalizationRepository { get; }
    IRepository<ContactMethodEntity> ContactMethodRepository { get; }
    IRepository<CandidateStatusEntity> CandidateStatusRepository { get; }
    IRepository<ApplicationStatusEntity> ApplicationStatusRepository { get; }
    IRepository<PositionStatusEntity> PositionStatusRepository { get; }
    IRepository<RolEntity> RolRepository{ get;}
    IRepository<SubRolEntity> SubRolRepository { get; }
    IRepository<ProjectEntity> ProjectRepository { get; }
    IRepository<AreaEntity> AreaRepository { get; }
    IRepository<UserEntity> UserRepository { get; }
    Task<int> SaveChangesAsync();
    void Dispose();
}