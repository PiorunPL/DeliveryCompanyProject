using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Domain.Administrator;
using DeliveryCompany.Domain.Courier;
using DeliveryCompany.Domain.User;
using Microsoft.IdentityModel.Tokens;

namespace DeliveryCompany.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    //private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator()
    {
        //_jwtSettings = jwtSettings;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key")
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "User")
        };

        var securityToken = new JwtSecurityToken(
            issuer: "DeliveryCompany",
            audience: "DeliveryCompany",
            expires: DateTime.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
        
    }

    public string GenerateToken(Courier courier)
    {
        throw new NotImplementedException();
    }

    public string GenerateToken(Administrator administrator)
    {
        throw new NotImplementedException();
    }
}