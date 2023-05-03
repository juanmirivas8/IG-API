using System.Security.Cryptography;
using System.Text;
using IGAPI.Dtos;
using IGAPI.Dtos.User;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;

namespace IGAPI.Services;

public class AuthService:IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Response<bool>> Register(UserDto request)
    {
        Response<bool> response = new Response<bool>();
        if (!request.Username.Trim().Any()||!request.Password.Trim().Any())
        {
            response.Success = false;
            response.Message = "Username or password cannot be empty";
            response.Data = false;
            return response;
        }
        var matchedList = await _unitOfWork.UserRepository.GetByFilter(x => x.Username == request.Username);
        if(matchedList.Any())
        {
            response.Success = false;
            response.Message = "Username already exists";
            response.Data = false;
            return response;
        }

        
        _createPasswordHash(request.Password, out var passwordHash, out var passwordSalt);
        UserEntity user = new UserEntity
        {
            Username = request.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        await _unitOfWork.UserRepository.Add(user);
        Console.WriteLine($"User {user.Username} created succesfully with id {user.Id} and password {user.PasswordHash}");
        response.Success = true;
        response.Message = "User created succesfully";
        response.Data = true;
        return response;
    }

    private void _createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
}