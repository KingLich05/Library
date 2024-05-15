using sultan.Domain.Models;

namespace sultan.Service;

public interface IBookAndUserService
{
    /// <summary>
    /// Возвращает список связей книг и пользователей
    /// </summary>
    /// <returns>Список связей книг и пользователей</returns>
    Task<List<BookAndUser>> GetBau();
    
    /// <summary>
    /// Получает список всех книг взятых одним пользователем
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Список книг пользователя</returns>
    Task<List<Temp>> GetBauOnlyPerson(int userId);
    
    /// <summary>
    /// Добавление книгу и пользователя к таблице BookAndUser 
    /// </summary>
    /// <param name="bookId">Идентификатор книги</param>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Возвращает успех функции. bool</returns>
    Task<bool> AddBook(int bookId, int userId);
    
    /// <summary>
    /// Возвращает книгу в библиотеку обратно
    /// </summary>
    /// <param name="bookId">Идентификатор книги</param>
    /// <param name="userId">Идентификатор пользователя</param>
    Task ReturnBook(int bookId, int userId);
    
    /// <summary>
    /// Отправка письма на почту пользователя
    /// </summary>
    Task MailService();
}