using Microsoft.AspNetCore.Mvc;
using sultan.Service;
using sultan.Web.ViewModels;

namespace sultan.Web.Controllers;

public class HomeController(IBookService bookService, IBookAndUserService bookAndUserService, ILogger<HomeController> logger) : Controller
{
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

    public async Task<IActionResult> Error()
    {
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> ReturnBook(int bookId, int userId)
    { 
        await bookAndUserService.ReturnBook(bookId, userId);
        return RedirectToAction("Index", "Home", new {id = userId});    
    }
    
    
    [HttpPost] 
    public async Task<IActionResult> AddBook(int bookId, int userId)
    {
        bool check = await bookAndUserService.AddBook(bookId, userId);
        
        if (check)
        {
            // await bookAndUserService.MailService();
            return RedirectToAction("Index", "Home", new {id = userId});
        }
        return RedirectToAction("Error", "Home");
    }
}