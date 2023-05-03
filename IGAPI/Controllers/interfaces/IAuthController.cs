using Azure;
using IGAPI.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.interfaces;

public interface IAuthController
{
    Task<ActionResult<Response<bool>>> Register(UserDto user);
}