using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace sultan.Application.Auth;


/// <summary>
/// Параметры Аутентификации
/// </summary>
public class AuthOptions {
    public const string ISSUER = "MyAuthServer"; 
    public const string AUDIENCE = "MyAuthClient";
    const string KEY = "mysupersecret_secretkey!123";
    public const int LIFETIME = 3; 
    
    /// <summary>
    /// Получает симметричный ключ для создания и валидации токена.
    /// </summary>
    /// <returns>Симметричный ключ.</returns>
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
