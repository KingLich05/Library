using System.ComponentModel.DataAnnotations;

namespace sultan.Domain.Models;
/// <summary>
/// модель временного хранения книг к определенному пользователю.    
/// </summary>
public class Temp : Entity
{
    /// <summary>
    /// Название книги.
    /// </summary>
    [Key]
    public string Name { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int idP { get; set; }
    
    /// <summary>
    /// Идентификатор книг.
    /// </summary>
    public int idB{ get; set; }
    
    /// <summary>
    /// Автор книги.
    /// </summary>
    public string Author { get; set; }
    
    /// <summary>
    /// Время когда пользователь взял книгу.
    /// </summary>
    public DateTime Time { get; set; }
}