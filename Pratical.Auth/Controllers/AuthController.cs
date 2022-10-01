using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rookie.AssetManagement.Contracts.Constants;

namespace Pratical.Auth.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Authentication(string name, string password)
    {
        if (name != "tuan" && password != "1")
            return BadRequest();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, name),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSettings.Key));
        var token = new JwtSecurityToken(
            issuer: JWTSettings.Issuer,
            audience: JWTSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(JWTSettings.DurationInMinutes),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
        );
        var response = new
        {
            accessToken = new JwtSecurityTokenHandler().WriteToken(token),
            expriresIn = DateTime.Now.AddMinutes(JWTSettings.DurationInMinutes),
        };
        return Ok(response);
    }
}
