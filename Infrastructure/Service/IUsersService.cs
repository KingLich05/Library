using sultan.Domain.Models;

namespace sultan.Service;

/// <summary>
/// Интерфейс сервиса для работы с пользователями
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Предоставляет список пользователей.
    /// </summary>
    /// <returns>Возвращает список пользователей.</returns>
    Task<List<Users>> GetUsersListAsync();
    
    /// <summary>
    /// Сохраняет пользователя в базе.
    /// </summary>
    /// <param name="user">Пользователь для сохранения.</param>
    /// <returns>Обновленный список пользователей</returns>
    Task<List<Users>> SavePersonDbAsync(Users user);
    
    /// <summary>
    /// Проверяет, существует ли данный пользователь
    /// </summary>
    /// <param name="username">Электронная почта пользователя.</param>
    /// <param name="password">Пароль пользователя.</param> 
    /// <returns>Объект пользователя, если он действителен, иначе null</returns>
    Task<Person> IsValidUserAsync(string username, string password);
    
}