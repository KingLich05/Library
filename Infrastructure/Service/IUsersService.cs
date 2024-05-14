using sultan.Domain.Models;

namespace sultan.Service;

public interface IUsersService
{
    Task<List<Users>> GetUsersListAsync();
    Task<List<Users>> SavePersonDbAsync(Users user);
    Task<Person> IsValidUserAsync(string username, string password);
    
}