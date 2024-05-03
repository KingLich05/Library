using Microsoft.AspNetCore.Mvc;
using sultan.Service;
using sultan.Web.ViewModels;


namespace sultan.Web.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        var viewModel = new BooksBAUViewModel()
        {
            Books = await BooksServices.GetBook(),
            BookAndUser = await BookAndUsersServices.GetBau(),
            idUser = id
        };
        return View(viewModel); 
    }
    
    [HttpPost] 
    public async Task<IActionResult> ReturnBook(int bookId, int userId)
    { 
        await BookAndUsersServices.ReturnBook(bookId, userId);
        return RedirectToAction("Index", "Home", new {id = userId});    
    }
    
    [HttpPost] 
    public async Task<IActionResult> AddBook(int bookId, int userId)
    {
        await BookAndUsersServices.AddBook(bookId, userId);
        
        return RedirectToAction("Index", "Home", new {id = userId});    
    }
}