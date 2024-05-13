using Microsoft.EntityFrameworkCore;
namespace sultan;

public class Context : DbContext
{
    public DbSet<Users> Users => Set<Users>();
    public DbSet<Books> Books => Set<Books>();
    public DbSet<BookAndUser> BookAndUsers => Set<BookAndUser>();
    public DbSet<Temp> Temps => Set<Temp>();
    public Context() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }
}