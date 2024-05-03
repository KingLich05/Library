using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using sultan.Db;
using sultan.Web.ViewModels;
namespace sultan.Web;

public class HomeController : Controller
{
    
    [HttpGet]
    public IActionResult Index(int id) 
    {       
        var viewModel = new BooksBAUViewModel()
        {
            Books = BooksDb.GetBook(),
            BookAndUser = BookAndUserDb.GetBau(),
            idUser = id
        };
        return View(viewModel); 
    }
    
    [HttpPost] 
    public IActionResult ReturnBook(int bookId, int userId)
    { 
        
        return RedirectToAction("Index", "Home", new {id = userId});    
    }
    
    [HttpPost] 
    public IActionResult AddBook(int bookId, int userId)
    {
        BookAndUserDb.AddBook(bookId, userId);
        return RedirectToAction("Index", "Home", new {id = userId});    
    }
}