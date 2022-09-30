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
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = JWTSettings.Issuer,
            ValidAudience = JWTSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSettings.Key))
        };
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
        var response = new
        {
            accessToken = encodedJwt,
            expriresIn = TimeSpan.FromMinutes(2).TotalSeconds
        };
        return Ok(response);
    }
}
