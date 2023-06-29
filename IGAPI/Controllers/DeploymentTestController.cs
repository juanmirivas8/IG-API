using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DeploymentTestController: ControllerBase
{
   
    [HttpGet("GetToken")]
    public String GetToken()
    {
        return Environment.GetEnvironmentVariable("JWT_TOKEN");
    }

    [HttpGet("GetConnectionStrings")]
    public String GetConnection()
    {
        return Environment.GetEnvironmentVariable("CONNECTION_STRING");
    }

    [HttpGet("GetASPENV")]
    public String GetAspEnv()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    }
}

