using Microsoft.AspNetCore.Mvc;
using sultan.Service;
using sultan.Web.ViewModels;

namespace sultan.Web.Controllers;


/// <summary>
/// Контроллер основной страницы
/// </summary>
/// <param name="bookService">Сервис для работы с книгами</param>
/// <param name="bookAndUserService">Сервис для работы со связями книг и пользователей</param>
/// <param name="logger">логгер</param>
public class HomeController(IBookService bookService, IBookAndUserService bookAndUserService, ILogger<HomeController> logger) : Controller
{
    
    /// <summary>
    /// Запускается основная страница с таблицей книг и авторизованным пользователем
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>список книг, список книг у одного пользователя и идентификатор авторизованного пользователя</returns>
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        var viewModel = new BooksBAUViewModel()
        {
            Books = await bookService.GetBookAsync(),
            Temps = await bookAndUserService.GetBauOnlyPerson(id),
            idUser = id
        };
        return View(viewModel);
    }

    
    /// <summary>
    /// Вызов представления, когда нет в наличии книг
    /// </summary>
    /// <returns>вызов представления</returns>
    public async Task<IActionResult> Error()
    {
        return View();
    }

    /// <summary>
    /// возвращает книгу в библиотеку
    /// </summary>
    /// <param name="bookId">Идентификатор книги</param>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Перенаправляет основную страницу</returns>
    [HttpPost]
    public async Task<IActionResult> ReturnBook(int bookId, int userId)
    { 
        await bookAndUserService.ReturnBook(bookId, userId);
        return RedirectToAction("Index", "Home", new {id = userId});    
    }
    
    
    /// <summary>
    /// Дает книгу пользователю и отправляет письмо на почту
    /// </summary>
    /// <param name="bookId">Идентификатор книги</param>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Если осталось в наличии книга, то возвращает True(на основную страницу), иначе False(ошибка)</returns>
    [HttpPost] 
    public async Task<IActionResult> AddBook(int bookId, int userId)
    {
        if (await bookAndUserService.AddBook(bookId, userId))
        {
            await bookAndUserService.MailService();
            return RedirectToAction("Index", "Home", new {id = userId});
        }
        return RedirectToAction("Error", "Home");
    }
}