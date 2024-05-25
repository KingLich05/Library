using Microsoft.EntityFrameworkCore;
using sultan.Domain.Models;

namespace sultan;

/// <summary>
/// Класс контекста базы данных для взаимодействия с таблицами пользователей, книг, связей книг и пользователей,
/// а также временных записей.
/// </summary>
public class Context : DbContext
{
    /// <summary>
    /// Таблица пользователей.
    /// </summary>
    public DbSet<Users> Users => Set<Users>();
    
    /// <summary>
    /// Таблица книг.
    /// </summary>
    public DbSet<Books> Books => Set<Books>();
    
    /// <summary>
    /// Таблица связи книг и пользователей.
    /// </summary>
    public DbSet<BookAndUser> BookAndUsers => Set<BookAndUser>();
    
    /// <summary>
    /// Таблица временных записей книг и одного пользователя.
    /// </summary>
    public DbSet<Temp> Temps => Set<Temp>();
    
    /// <summary>
    /// Создание базы данных.
    /// </summary>
    public Context() => Database.EnsureCreated();
    
    /// <summary>
    /// Настройка БД.
    /// </summary>
    /// <param name="optionsBuilder">Сервис, который помогает настроить БД.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("host=localhost;port=5432;Database=library;User Id = postgres;Password=sultan;");
    }
}