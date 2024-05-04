namespace sultan.Service;

public interface IBookAndUserService
{
    Task<List<BookAndUser>> GetBau();
    Task AddBook(int bookId, int userId);
    Task ReturnBook(int bookId, int userId);
    Task MailService();
}