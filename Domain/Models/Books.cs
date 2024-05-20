namespace sultan.Domain.Models;

/// <summary>
/// Модель книг.
/// </summary>
public class Books : Entity
{
    /// <summary>
    /// Название книги.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Автор книги.
    /// </summary>
    public string Author { get; set; } = null!;
    
    /// <summary>
    /// Количество книг в наличии.
    /// </summary>
    public int Presence { get; set; }
}