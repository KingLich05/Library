using sultan.Domain.Models;

namespace sultan;

public class Person : Entity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}