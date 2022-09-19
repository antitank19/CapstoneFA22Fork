using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.EntitiesForManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.IService;

namespace Service.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, user.Role.RoleName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:NotTokenKeyForSureSourceTrustMeDude"]));

        var credential = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credential);

        return tokenHandler.WriteToken(token);
    }
}