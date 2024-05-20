namespace sultan.Domain.Models;

/// <summary>
/// Представляет сущность пользователя.
/// </summary>
public class Person : Entity
{
    /// <summary>
    /// Имя определенного пользователя.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Электронная почта определенного пользователя.
    /// </summary>
    public string Email { get; set; } = null!;
    
    /// <summary>
    /// Хешированный пароль определенного пользователя.
    /// </summary>
    public string Password { get; set; } = null!;
}