using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sultan.Domain.Models;
using sultan.Service;

namespace sultan.Web.Controllers;

public class AccountController(
    IConfiguration configuration,
    IUsersService usersService,
    IHttpClientFactory httpClientFactory) : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("/token")]
    public async Task<IActionResult> Login(Person model)
    {
        Person person = await usersService.IsValidUserAsync(model.Email, model.Password);
        if (person != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Email)
            };
            var token = await GenerateTokenAsync(model.Email);
            var httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return RedirectToAction("Index", "Home", new { id = person.Id});
        }
        return Unauthorized();
    }

    private Task<string> GenerateTokenAsync(string username)
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
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}