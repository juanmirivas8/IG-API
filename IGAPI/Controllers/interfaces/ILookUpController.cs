using IGAPI.Dtos;
using IGAPI.Dtos.Localization;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.interfaces;

public interface ILookUpController
{
   Task<ActionResult<Response<IEnumerable<ObjectWithKey>>>> GetAllLookUps();
}