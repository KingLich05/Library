using Microsoft.AspNetCore.Mvc;
using sultan;
namespace sultan.Db;

public class UsersDb
{
    private static Context _db = new Context();
    
    public static List<Users> GetUsersList()
    {
        var users = _db.Users.ToList();
        return users;
    }

    public static List<Users> SavePersonDB(Users user)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);  
        Users person = new Users{Name = user.Name, Email = user.Email, Password = passwordHash};
        _db.Users.Add(person);
        _db.SaveChanges();
        return GetUsersList();
    }

    public static Users IsValidUser(string username, string password)
    {
        var people = GetUsersList();
        var person = people.FirstOrDefault(p => p.Email == username && BCrypt.Net.BCrypt.Verify(password, p.Password));
        return person;
    }
}