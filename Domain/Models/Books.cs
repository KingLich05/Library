using Microsoft.EntityFrameworkCore;
using sultan.Domain.Models;

namespace sultan;

public class Books : Entity
{
    public string Name { get; set; } = null!;
    public string Author { get; set; } = null!;
}