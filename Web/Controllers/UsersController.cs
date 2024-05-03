using Microsoft.AspNetCore.Mvc;
using sultan.Service;

namespace sultan.Web.Controllers;

public class UsersController : Controller
{
    [HttpGet]
    public IActionResult Auth()
    {
        return View(UsersServices.GetUsersList());
    }

    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegPerson(sultan.Users user)
    {
        UsersServices.SavePersonDB(user);
        return RedirectToAction("Auth", "Users");
    }
}