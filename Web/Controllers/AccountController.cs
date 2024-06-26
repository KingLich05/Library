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
/// <param name="jwtTokenGenerator">Cоздание JWT Token</param>
public class AccountController(
    IConfiguration configuration,
    IUsersService usersService,
    IHttpClientFactory httpClientFactory,
    IJwtTokenGenerator jwtTokenGenerator) : Controller
{
    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="model">Это данные которые пришли с представления с формы авторизации.</param>
    /// <returns>Если пользователь найден и авторизация прошла успешно, возвращает на начальную страницу, иначе "Unauthorized".</returns>
    [HttpPost]
    [Route("/token")]
    public async Task<IActionResult> Login(Person model)
    {
        Person person = await usersService.IsValidUserAsync(model.Email, model.Password);
        if (person != null)
        {
            var token = await jwtTokenGenerator.GenerateTokenAsync(person.Email);
            var httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return RedirectToAction("Index", "Home", new { id = person.Id});
        }
        return Unauthorized();
    }
}