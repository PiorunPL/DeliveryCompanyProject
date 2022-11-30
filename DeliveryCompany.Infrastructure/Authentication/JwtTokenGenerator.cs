using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DeliveryCompany.Application.Common.Interfaces.Authentication;
using DeliveryCompany.Domain.Administrator;
using DeliveryCompany.Domain.Common;
using DeliveryCompany.Domain.Courier;
using DeliveryCompany.Domain.Client;
using Microsoft.IdentityModel.Tokens;

namespace DeliveryCompany.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    //private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator()
    {
        //_jwtSettings = jwtSettings;
    }

    public string GenerateToken(Client client)
    {
        return GenerateToken(client, "Client");
    }

    public string GenerateToken(Courier courier)
    {
        return GenerateToken(courier, "Courier");
    }

    public string GenerateToken(Administrator administrator)
    {
        return GenerateToken(administrator, "Administrator");
    }

    private string GenerateToken(Person person, string role){
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key")
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, person.Id.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, person.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, person.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, role)
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
}