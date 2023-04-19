using IGAPI.Dtos;
using IGAPI.Dtos.Candidate;
using IGAPI.Dtos.User;
using IGAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers.interfaces
{
    public interface IAuthController
    {
        Task<ActionResult<Response<UserResponseDto>>> AdminLogIn(string email, string password);
        Task<ActionResult<Response<CandidateResponseDto>>> GuestLogIn(string email, string password);
        Task<ActionResult<Response<UserResponseDto>>> CreateUser([FromBody] UserPostDto user);
        Task<ActionResult<Response<UserResponseDto>>> UpdateUser([FromBody] UserPutDto user);
        Task<ActionResult<Response<string>>> DeleteUser([FromBody] UserPutDto user);

    }
}
