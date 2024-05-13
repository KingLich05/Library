using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using sultan;
using System.Net.Mail;
using BCrypt.Net;
namespace sultan.Service;

public interface ITemp
{
    void GetListAsync();
    
}
