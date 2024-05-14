using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sultan.Domain.Models;

namespace sultan.Application.Auth;

public class Auth
{
    public static string GetToken(Users user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email)
        };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        
        return encodedJwt;
    }
}