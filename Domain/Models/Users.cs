namespace sultan.Domain.Models;


/// <summary>
/// Модель пользователей.
/// </summary>
public class Users : Entity
{
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// электронная почта пользователя.
    /// </summary>
    public string Email { get; set; } = null!;
    
    /// <summary>
    /// хешированный пароль пользователя.
    /// </summary>
    public string Password { get; set; } = null!;
}