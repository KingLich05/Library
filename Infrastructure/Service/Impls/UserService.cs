using Microsoft.EntityFrameworkCore;
using sultan.Domain.Models;

namespace sultan.Service.Impls;

/// <summary>
/// Сервис для работы с пользователями, наследующий базовый сервис и реализующий интерфейс IUserService.
/// </summary>
public class UserService : IUsersService
{
    private static readonly Context Db = new Context();
    private readonly IPasswordHashingService _hashPass = new PasswordHashingService();
    /// <summary>
    /// Предоставляет список пользователей
    /// </summary>
    /// <returns>Список пользователей</returns>
    public async Task<List<Users>> GetUsersListAsync()
    {
        return await Db.Users.ToListAsync();
    }

    /// <summary>
    ///  Сохраняет пользователя в базе.
    /// </summary>
    /// <param name="user">Пользователь для сохранения.</param>
    /// <returns>Обновленный список пользователей</returns>
    public async Task<List<Users>> SavePersonDbAsync(Users user)
    {
        Users person = new Users { Name = user.Name, Email = user.Email, Password = await _hashPass.HashPassword(user.Password) };
        Db.Users.Add(person);
        await Db.SaveChangesAsync();
        return await GetUsersListAsync();
    }

    
    /// <summary>
    /// Проверяет, существует ли данный пользователь
    /// </summary>
    /// <param name="username">Электронная почта пользователя.</param>
    /// <param name="password">Пароль пользователя.</param> 
    /// <returns>Объект пользователя, если он действителен, иначе null</returns>
    public async Task<Person> IsValidUserAsync(string username, string password)
    {
        var people = await GetUsersListAsync();
        var person = people.FirstOrDefault(p => p.Email == username && _hashPass.CheckPassword(password, p.Password));
        if (person != null)
        {
            var newPerson = ConvertToPerson(person);
            return newPerson;    
        }
        return null;
    }
    
    /// <summary>
    /// Преобразование из Users в Person
    /// </summary>
    /// <param name="user">Преобразование пользователя</param>
    /// <returns>Возвращает преобразованного пользователя</returns>
    static Person ConvertToPerson(Users user)
    {
        Person person = new Person
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };
        return person;
    }
}