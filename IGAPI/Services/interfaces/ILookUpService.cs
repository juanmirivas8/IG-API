
using IGAPI.Dtos;
using IGAPI.Dtos.Localization;

namespace IGAPI.Services.interfaces;

public interface ILookUpService
{
    Task<Response<IEnumerable<ObjectWithKey>>> GetAllLookUps();
}