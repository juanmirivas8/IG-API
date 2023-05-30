using IGAPI.Models;
using IGAPI.Repositories.Interfaces;

namespace IGAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public DataContext Context { get; }
    public IRepository<LocalizationEntity> LocalizationRepository { get; }
    public IRepository<ContactMethodEntity> ContactMethodRepository { get; }
    public IRepository<CandidateStatusEntity> CandidateStatusRepository { get; }
    public IRepository<ApplicationStatusEntity> ApplicationStatusRepository { get; }
    public IRepository<PositionStatusEntity> PositionStatusRepository { get; }
    public IRepository<RolEntity> RolRepository { get; }
    public IRepository<SubRolEntity> SubRolRepository { get; }
    public IRepository<ProjectEntity> ProjectRepository { get; }
    public IRepository<AreaEntity> AreaRepository { get; }
    public IRepository<UserEntity> UserRepository { get; }
    public IPositionRepository PositionRepository { get; }

    public UnitOfWork(DataContext context,IRepository<LocalizationEntity> localizationRepository,IRepository<ContactMethodEntity> contactMethodRepository,
        IRepository<CandidateStatusEntity> candidateStatusRepository,IRepository<ApplicationStatusEntity> applicationStatusRepository,
        IRepository<PositionStatusEntity> positionStatusRepository, IRepository<RolEntity> rolRepository, IRepository<SubRolEntity> subRolRepository,
        IRepository<ProjectEntity> projectRepository,IRepository<AreaEntity> areaRepository, IRepository<UserEntity> userRepository,
        IPositionRepository positionRepository)
    {
        Context = context;
        LocalizationRepository = localizationRepository;
        ContactMethodRepository = contactMethodRepository;
        CandidateStatusRepository = candidateStatusRepository;
        ApplicationStatusRepository = applicationStatusRepository;
        PositionStatusRepository = positionStatusRepository;
        RolRepository = rolRepository;
        SubRolRepository = subRolRepository;
        ProjectRepository = projectRepository;
        AreaRepository = areaRepository;
        UserRepository = userRepository;
        PositionRepository = positionRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}