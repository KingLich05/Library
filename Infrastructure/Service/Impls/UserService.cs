namespace sultan.Service.Impls;

public class UserService : IUsersService
{
    private static readonly Context _db = new Context();

    public async Task<List<Users>> GetUsersListAsync()
    {
        var users = await Task.Run(() => _db.Users.ToList());
        return users;
    }

    public async Task<List<Users>> SavePersonDbAsync(Users user)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        Users person = new Users { Name = user.Name, Email = user.Email, Password = passwordHash };
        _db.Users.Add(person);
        await _db.SaveChangesAsync();
        return await GetUsersListAsync();
    }

    public async Task<Users> IsValidUserAsync(string username, string password)
    {
        var people = await GetUsersListAsync();
        var person = people.FirstOrDefault(p => p.Email == username && BCrypt.Net.BCrypt.Verify(password, p.Password));
        return person;
    }
}