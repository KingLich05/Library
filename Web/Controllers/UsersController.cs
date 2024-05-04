using Microsoft.AspNetCore.Mvc;
using sultan.Service;

namespace sultan.Web.Controllers;

public class UsersController(IUsersService usersService) : Controller
{
    [HttpGet]
    public IActionResult Auth()
    {
        return View(usersService.GetUsersListAsync());
    }

    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegPerson(sultan.Users user)
    {
        usersService.SavePersonDbAsync(user);
        return RedirectToAction("Auth", "Users");
    }
}