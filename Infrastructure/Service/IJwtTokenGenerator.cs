namespace sultan.Service;

public interface IJwtTokenGenerator
{
    /// <summary>
    /// Создание JWT токена.
    /// </summary>
    /// <param name="username">Электронная почта пользователя.</param>
    /// <returns>Строку токена.</returns>
    Task<string> GenerateTokenAsync(string username);

}