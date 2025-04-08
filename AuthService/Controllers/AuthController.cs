using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController(IConfiguration configuration) : ControllerBase
{
    private static ConcurrentDictionary<string, string> UserData { get; set; } = new();
    
    //api/auth/login/{email}/{password} 
    [HttpPost("login/{email}/{password}")]
    public async Task<IActionResult> Login(string email, string password)
    {
        await Task.Delay(500);
        var getEmail = UserData!.Keys.FirstOrDefault(e => e.Equals(email));
        if (!string.IsNullOrEmpty(getEmail))
        {
            UserData.TryGetValue(getEmail, out string? dbPassword);
            if (!Equals(dbPassword, password)) 
                return BadRequest("Invalid credentials");
            string jwtToken = GenerateToken(email);
            return Ok(jwtToken);
        }
        return NotFound("Email not found");
    }

    private string GenerateToken(string getEmail)
    {
        var key = Encoding.UTF8.GetBytes(configuration["Authentication:Key"]!);
        var securityKey = new SymmetricSecurityKey(key);
        var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[] { new Claim(ClaimTypes.Email, getEmail!) };
        var token = new JwtSecurityToken(
            issuer: configuration["Authentication:Issuer"],
            audience: configuration["Authentication:Audience"],
            claims: claims,
            expires: null,
            signingCredentials: credential);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("Register/{email}/{password}")]
    public async Task<IActionResult> Register(string email, string password)
    {
        await Task.Delay(500);
        var getEmail = UserData!.Keys.FirstOrDefault(e => e.Equals(email));
        if (!string.IsNullOrEmpty(getEmail))
            return BadRequest("User already exist");

        UserData[email] = password;
        return Ok("User create successfully");
    }
}









