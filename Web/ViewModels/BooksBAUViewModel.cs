using sultan.Domain.Models;

namespace sultan.Web.ViewModels;

/// <summary>
/// передача моделей в представление
/// </summary>
public class BooksBAUViewModel
{
    /// <summary>
    /// Модель книг
    /// </summary>
    public List<Books> Books { get; set; }
    
    
    /// <summary>
    /// Модель связи между книгами и пользователем
    /// </summary>
    public List<Temp> Temps { get; set; }
    
    /// <summary>
    /// передача идентификатора пользователя, который вошел в систему
    /// </summary>
    public int idUser { get; set; }
}