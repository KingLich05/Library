using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using sultan.Application.Auth;
using sultan.Db;

namespace sultan.Web;

public class Users : Controller
{
    [HttpGet]
    public IActionResult Auth()
    {
        return View(UsersDb.GetUsersList());
    }

    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegPerson(sultan.Users user)
    {
        UsersDb.SavePersonDB(user);
        return RedirectToAction("Auth", "Users");
    }

    // [HttpPost]
    // public IActionResult Authorization(sultan.Users user)
    // {
    //     var people = UsersDb.GetUsersList();
    //     
    //     var hash1 = BCrypt.Net.BCrypt.HashPassword(user.Password);  
    //     var person = people.FirstOrDefault(p => p.Email == user.Email&& BCrypt.Net.BCrypt.Verify(user.Password, p.Password));
    //     var encodedJwt = Application.Auth.Auth.GetToken(user);
    //     var response = new
    //     {
    //         access_token = encodedJwt,
    //         username = person.Email,
    //         id = person.Id
    //     };
    //     
    //     return RedirectToAction("Index","Home");
    // }
}