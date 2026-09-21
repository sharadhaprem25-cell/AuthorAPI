using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    public AuthController(IConfiguration config) => _config = config;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest user)
    {
        // Simple authentication check placeholder
        if (user.Username == "admin" && user.Password == "SecurePass123!")
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
        return Unauthorized();
    }
}
public class LoginRequest { public string Username { get; set; } public string Password { get; set; } }
