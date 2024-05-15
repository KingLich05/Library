using sultan.Domain.Models;

namespace sultan.Service;

public abstract class IBookService
{
    /// <summary>
    /// Возвращает список книг из бд
    /// </summary>
    /// <returns>Список книг</returns>
    public abstract Task<List<Books>> GetBookAsync();
    
    /// <summary>
    /// Добавляет 12 книг в бд 
    /// </summary>
    /// <returns>список книг</returns>
    public abstract Task<List<Books>> FillLibrary();
}