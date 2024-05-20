namespace sultan.Service.Impls;

public class PasswordHashingService : IPasswordHashingService
{
    /// <summary>
    /// Хешируется пароль.
    /// </summary>
    /// <param name="password">Пароль который нужно превратить в хеш.</param>
    /// <returns>Возвращается хешированный пароль.</returns>
    public async Task<string> HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    
    /// <summary>
    /// Проверяет, совпадает ли введенный пароль от хеш-пароля.
    /// </summary>
    /// <param name="password">Введенный пароль пользователя.</param>
    /// <param name="hash">Хешированный пароль пользователя.</param>
    /// <returns>Возвращает bool.</returns>
    public bool CheckPassword(string password,string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}