namespace sultan.Service;

public interface IBookAndUserService
{
    Task<List<BookAndUser?>> GetBau();
    Task<List<Temp?>> GetBauOnlyPerson(int userId);
    Task AddBook(int bookId, int userId);
    Task ReturnBook(int bookId, int userId);
    Task MailService();
}