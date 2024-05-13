using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using sultan.Service;
using sultan.Web.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;

namespace sultan.Web.Controllers;

public class HomeController(IBookService bookService, IBookAndUserService bookAndUserService, ILogger<HomeController> logger) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        var viewModel = new BooksBAUViewModel()
        {
            Books = await bookService.GetBook(),
            Temps = await bookAndUserService.GetBauOnlyPerson(id),
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