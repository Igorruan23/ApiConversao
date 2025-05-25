using APIConversao.Models;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIConversao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;

        private readonly Dictionary<string, string> users = new()
        {
        {"admin", "1234"},
        {"user1", "senha1"}
        };

        public AuthController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            if (!users.ContainsKey(request.UserName) || users[request.UserName] != request.Password)
                return Unauthorized("Credenciais invalidas");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "123"),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtConfig:Issuer"],
                audience: _config["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
                );
            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = tokenstring });
        }
    }
}
