using IGAPI.Controllers.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IGAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PositionController:ControllerBase,IPositionController
{
    
}