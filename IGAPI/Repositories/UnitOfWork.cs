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
    
    public void Attach(PositionEntity positionEntity)
    {
        if(!Context.Exists(positionEntity)) Context.Positions.Attach(positionEntity);
        if(!Context.Exists(positionEntity.Project)) Context.Projects.Attach(positionEntity.Project);
        if(!Context.Exists(positionEntity.Area)) Context.Areas.Attach(positionEntity.Area);
        if(!Context.Exists(positionEntity.Rol)) Context.Roles.Attach(positionEntity.Rol);
        if(!Context.Exists(positionEntity.SubRol)) Context.SubRoles.Attach(positionEntity.SubRol);
        if(!Context.Exists(positionEntity.Localization)) Context.Localizations.Attach(positionEntity.Localization);
        if(!Context.Exists(positionEntity.Status)) Context.PositionStatus.Attach(positionEntity.Status);
        
        foreach (var application in positionEntity.Applications)
        {
            if(!Context.Exists(application)) Attach(application);
        }
    }
    
    public void Attach(CandidateEntity candidateEntity)
    {
        if(!Context.Exists(candidateEntity)) Context.Candidates.Attach(candidateEntity);
        if(!Context.Exists(candidateEntity.Status)) Context.CandidateStatus.Attach(candidateEntity.Status);
        if(!Context.Exists(candidateEntity.ContactMethod)) Context.ContactMethods.Attach(candidateEntity.ContactMethod);

        foreach (var application in candidateEntity.Applications)
        {
            if(!Context.Exists(application)) Attach(application);
        }
    }
    
    public void Attach(ApplicationEntity applicationEntity)
    {
        if(!Context.Exists(applicationEntity)) Context.Applications.Attach(applicationEntity);
        if(!Context.Exists(applicationEntity.Status)) Context.ApplicationStatus.Attach(applicationEntity.Status);
        
        if(!Context.Exists(applicationEntity.Candidate)) Attach(applicationEntity.Candidate);
        if(!Context.Exists(applicationEntity.Position)) Attach(applicationEntity.Position);
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