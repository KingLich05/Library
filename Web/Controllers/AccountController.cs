using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sultan.Service;

namespace sultan.Web.Controllers;

public class AccountController(IConfiguration configuration, IUsersService usersService) : Controller
{
    [HttpPost]
    [Route("/token")]
    public IActionResult Login(Person model)
    {
        var person = usersService.IsValidUserAsync(model.Email, model.Password);
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email)
            };
            var identity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(principal);
            var token = GenerateToken(model.Email);
            return RedirectToAction("Index", "Home",new { id = person.Id }); 
        }
    }

    private string GenerateToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(3), 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}