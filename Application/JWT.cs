using Microsoft.IdentityModel.Tokens;
using sultan.Application.Auth;
using sultan;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace sultan.Application;


/// <summary>
/// Класс для работы с JWT.
/// </summary>
public abstract class Jwt()
{
    
    /// <summary>
    /// Настройки JWT.
    /// </summary>
    /// <param name="options">Настройки аутентификации.</param>
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