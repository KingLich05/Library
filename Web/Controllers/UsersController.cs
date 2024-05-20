using Microsoft.AspNetCore.Mvc;
using sultan.Domain.Models;
using sultan.Service;

namespace sultan.Web.Controllers;

/// <summary>
/// Авторизация и аутентификация пользователя.
/// </summary>
/// <param name="usersService">Сервис дял работы с пользователем.</param>
public class UsersController(IUsersService usersService) : Controller
{
    /// <summary>
    /// Получение списка пользователей.
    /// </summary>
    /// <returns>Список пользователей.</returns>
    [HttpGet]
    public async Task<IActionResult> Auth()
    {
        return View(await usersService.GetUsersListAsync());
    }

    
    /// <summary>
    /// Регистрация.
    /// </summary>
    /// <returns>Форма для регистрации.</returns>
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    /// <summary>
    /// Регистрация пользователя в бд. 
    /// </summary>
    /// <param name="user">Модель пользователя.</param>
    /// <returns>Открывает Форму авторизации пользователя.</returns>
    [HttpPost]
    public async Task<IActionResult> RegPerson(Users user)
    {
        await usersService.SavePersonDbAsync(user);
        return RedirectToAction("Auth", "Users");
    }
}