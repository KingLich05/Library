using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sultan.Service;


namespace sultan.Web;

public class AccountController : Controller
{
    
    private readonly IConfiguration _configuration;

    public AccountController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [Route("/token")]
    public IActionResult Login(Person model)
    {
        var person = UsersServices.IsValidUser(model.Email, model.Password);
        if (person != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, person.Email)
            };
            var identity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(principal);
            var token = GenerateToken(person.Email);
            return RedirectToAction("Index", "Home",new { id = person.Id }); 
        }
        else
        {
            Console.WriteLine("не авторизован");
            return Unauthorized();
        }
    }

    private string GenerateToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

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



