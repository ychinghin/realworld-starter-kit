using Microsoft.IdentityModel.Tokens;
using Server.Domain.User;
using Server.Domain.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Identity;

public class JwtService : IJwtService
{
    private readonly JwtConfig _config;
    public JwtService(JwtConfig config) {
        _config = config;
    }

    public string GenerateToken(UserDomainModel user)
    {
        var claims = new List<Claim>()
        {
            new Claim("Username", user.Username),
            new Claim("Email", user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
        var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _config.Issuer,
            _config.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signing
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}