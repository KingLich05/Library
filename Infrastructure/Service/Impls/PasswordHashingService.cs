namespace sultan.Service.Impls;

public class PasswordHashingService : IPasswordHashingService
{
    /// <summary>
    /// хешируется пароль
    /// </summary>
    /// <param name="password">Пароль который нужно превратить в хеш</param>
    /// <returns>возвращается хешированный пароль</returns>
    public async Task<string> HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    
    /// <summary>
    /// Проверяет, совпадает ли введенный пароль от хеш-пароля
    /// </summary>
    /// <param name="password">введенный пароль пользователя</param>
    /// <param name="hash">хешированный пароль пользователя</param>
    /// <returns>Возвращает bool</returns>
    public bool CheckPassword(string password,string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}