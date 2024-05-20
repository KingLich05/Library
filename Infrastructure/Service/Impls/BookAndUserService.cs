using Microsoft.EntityFrameworkCore;
using sultan.Domain.Models;
using sultan.Web;

namespace sultan.Service.Impls;

/// <summary>
/// Сервис для работы с теми книгами, которые были взяты, наследующий базовый сервис и реализующий интерфейс IBookAndService.
/// </summary>
public class BookAndUserService : IBookAndUserService
{
    
    private readonly IBookService _bookService;
    

    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="bookService">Сервис для работы с книгами.</param>
    public BookAndUserService(IBookService bookService)
    {
        _bookService = bookService;
    }
    private static readonly Context Db = new Context();

    
    /// <summary>
    /// Возвращает список связей книг и пользователей.
    /// </summary>
    /// <returns>Список связей книг и пользователей.</returns>
    public async Task<List<BookAndUser>> GetBau()
    {
        return await Db.BookAndUsers.ToListAsync();
    }

    
    /// <summary>
    /// Добавление книгу и пользователя к таблице BookAndUser.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Возвращает успех функции. bool.</returns>
    public async Task<bool> AddBook(int bookId, int userId)
    {
        if (!await Presence(bookId)) return false;
        
        var books = await _bookService.GetBookAsync();
        Books? book = await Db.Books.FindAsync(bookId);
        
        book!.Presence -= 1;
        books[bookId - 1].Presence -= 1;
        BookAndUser addTemp = new BookAndUser { idUser = userId, idBook = bookId, Term = DateTime.Now };
        
        Db.BookAndUsers.Add(addTemp);
        await Db.SaveChangesAsync();
        return true;
    }

    
    /// <summary>
    /// Проверяет, осталась ли в наличие книга.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <returns>True если осталась, иначе false.</returns>
    private async Task<bool> Presence(int bookId)
    {
        var books = await _bookService.GetBookAsync();
        if (books[bookId - 1].Presence > 0)
        {
            return true;
        }
        return false;
    }

    
    /// <summary>
    /// Возвращает книгу в библиотеку обратно.
    /// </summary>
    /// <param name="bookId">Идентификатор книги.</param>
    /// <param name="userId">Идентификатор пользователя.</param>
    public async Task ReturnBook(int bookId, int userId)
    {
        var bau = await GetBau();
        var books = await _bookService.GetBookAsync();
        
        Books? book = Db.Books.FirstOrDefault(b => b.Id == bookId);
        book!.Presence += 1;
        
        books[bookId - 1].Presence += 1; 
        
        BookAndUser? deleteBook = bau.FirstOrDefault(b => b.idBook == bookId && userId == b.idUser);
        Db.BookAndUsers.Remove(deleteBook!);
        await Db.SaveChangesAsync();
    }

    
    
    /// <summary>
    /// Получает список всех книг взятых одним пользователем.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список книг пользователя.</returns>
    public async Task<List<Domain.Models.Temp>> GetBauOnlyPerson(int userId)
    {
        Db.Temps.RemoveRange(Db.Temps);
        await Db.SaveChangesAsync();

        return await ProcessSelectedPerson(userId);
    }

    
    /// <summary>
    /// Обрабатывает список книг, выбранных определенным пользователем.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список временных записей для выбранного пользователя.</returns>
    public async Task<List<Domain.Models.Temp>> ProcessSelectedPerson(int userId)
    {
        var bau = await GetBau();
        var books = await _bookService.GetBookAsync();
        
        var temporary = from b in bau
            join i in books on b.idBook equals i.Id
            select new { idP = b.idUser, idB = b.idBook, Name = i.Name, Author = i.Author, Time = b.Term };

        var selectedPerson = from b in temporary
            where b.idP == userId
            select b;

        foreach (var emp in selectedPerson)
        {
            DateTime time = emp.Time;
            var t = new Domain.Models.Temp
            {
                idB = emp.idB,
                idP = emp.idP,
                Author = emp.Author,
                Name = emp.Name,
                Time = time
            };
            Db.Temps.Add(t);
        }

        await Db.SaveChangesAsync();

        return await Db.Temps.ToListAsync();
    }
}