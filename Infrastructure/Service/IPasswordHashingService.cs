namespace sultan.Service;

public interface IPasswordHashingService
{
    /// <summary>
    /// Создание хеш пароля
    /// </summary>
    /// <param name="password">строка которую нужно преобразовать в хеш</param>
    /// <returns></returns>
    Task<string> HashPassword(string password);

    
    /// <summary>
    /// Проверяет введеный пароль с хэшом
    /// </summary>
    /// <param name="password">Пароль с формы</param>
    /// <param name="hash">Хеш пароль с бд</param>
    /// <returns></returns>
    bool CheckPassword(string password, string hash);
}