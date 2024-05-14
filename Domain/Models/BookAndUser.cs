namespace sultan.Domain.Models;

/// <summary>
/// модель связи книг и пользователей
/// </summary>
public class BookAndUser : Entity
{
    /// <summary>
    /// Уникальный Идентификатор книги, которую взял пользователь
    /// </summary>
    public int idBook { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя, который взял книгу
    /// </summary>
    public int idUser { get; set; }
    
    /// <summary>
    /// Дата и время когда была взята книга
    /// </summary>
    public DateTime Term { get; set; }
}