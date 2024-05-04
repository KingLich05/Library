using Microsoft.AspNetCore.Mvc;
using sultan.Service;
using sultan.Web.ViewModels;


namespace sultan.Web.Controllers;

public class HomeController(IBookService bookService, IBookAndUserService bookAndUserService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        var viewModel = new BooksBAUViewModel()
        {
            Books = await bookService.GetBook(),
            BookAndUser = await bookAndUserService.GetBau(),
            idUser = id
        };
        return View(viewModel); 
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
        await bookAndUserService.AddBook(bookId, userId);
        // await BookAndUsersServices.MailService();
        return RedirectToAction("Index", "Home", new {id = userId});    
    }
}