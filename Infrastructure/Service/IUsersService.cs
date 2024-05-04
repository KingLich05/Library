namespace sultan.Service;

public interface IUsersService
{
    Task<List<Users>> GetUsersListAsync();
    Task<List<Users>> SavePersonDbAsync(Users user);
    Task<Users> IsValidUserAsync(string username, string password);
    
}