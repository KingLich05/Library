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
public class HomeController(IBookService bookService, IBookAndUserService bookAndUserService, IMailService mailService) : Controller
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
    /// возвращает строку, когда нет в наличии книг
    /// </summary>
    /// <returns>строка о том что книга занята</returns>
    public async Task<string> Error()
    {
        return "Эта книга уже занята";
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
            await mailService.SendMail();
            return RedirectToAction("Index", "Home", new {id = userId});
        }
        return RedirectToAction("Error", "Home");
    }
}