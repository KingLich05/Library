using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sultan.Domain.Models;
using sultan.Service;

namespace sultan.Web.Controllers;

/// <summary>
/// Контроллер. Авторизация пользователя
/// </summary>
/// <param name="configuration">конфигурация</param>
/// <param name="usersService">сервис для работы с пользователем</param>
/// <param name="httpClientFactory">создание http клиента</param>
public class AccountController(
    IConfiguration configuration,
    IUsersService usersService,
    IHttpClientFactory httpClientFactory) : Controller
{
    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="model">это данные которые пришли с представления с формы авторизации</param>
    /// <returns>Если пользователь найден и авторизация прошла успешно, возвращает на начальную страницу, иначе "Unauthorized"</returns>
    [HttpPost]
    [Route("/token")]
    public async Task<IActionResult> Login(Person model)
    {
        Person person = await usersService.IsValidUserAsync(model.Email, model.Password);
        if (person != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, person.Email)
            };
            var token = await GenerateTokenAsync(person.Email);
            var httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return RedirectToAction("Index", "Home", new { id = person.Id});
        }
        return Unauthorized();
    }

    
    /// <summary>
    /// Генерирует и настраивает токен
    /// </summary>
    /// <param name="username">Электронная почта пользователя</param>
    /// <returns>Возращает сгенерированный токен</returns>
    private async Task<string> GenerateTokenAsync(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(3),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}