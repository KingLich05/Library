using Microsoft.IdentityModel.Tokens;
using sultan.Application.Auth;
using sultan;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace sultan.Application;

public abstract class Jwt()
{
    public static void jwt(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    }
    
   
}