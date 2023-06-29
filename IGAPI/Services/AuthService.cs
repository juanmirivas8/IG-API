using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IGAPI.Dtos;
using IGAPI.Dtos.User;
using IGAPI.Models;
using IGAPI.Repositories.Interfaces;
using IGAPI.Services.interfaces;
using Microsoft.IdentityModel.Tokens;

namespace IGAPI.Services;

public class AuthService:IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Response<bool>> Register(UserRequestDto request)
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

    public async Task<Response<UserResponseDto>> Login(UserRequestDto request)
    {
        Response<UserResponseDto> response = new Response<UserResponseDto>();
        var matchedList = await _unitOfWork.UserRepository.GetByFilter(x => x.Username == request.Username);
        if (!matchedList.Any())
        {
            response.Success = false;
            response.Message = "Username is wrong";
            response.Data = null;
            return response;
        }

        var user = matchedList.First();
        if (!_verifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Password is wrong";
            response.Data = null;
            return response;
        }

        response.Success = true;
        response.Message = "Login successful";
        response.Data = new UserResponseDto
        {
            Id = user.Id,
            Username = user.Username
        };
        response.Data.Token = _generateJwtToken(response.Data);
        return response;
    }

    private string _generateJwtToken(UserResponseDto responseData)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, responseData.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, responseData.Username)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_TOKEN")));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(claims : claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);
        
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }

    private void _createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
    
    private bool _verifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        return computedHash.SequenceEqual(passwordHash);
    }
}