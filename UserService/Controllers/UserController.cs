using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    private static readonly string[] Users = new[]
    {
        "NavChat", "NavDesk", "NavIa"
    };

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await Task.Delay(4000);
        _logger.LogInformation("Get method called"); 
        return Ok(Users);
    }
}

