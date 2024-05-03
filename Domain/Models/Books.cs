using Microsoft.EntityFrameworkCore;
namespace sultan;

public class Books
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Author { get; set; } = null!;
}