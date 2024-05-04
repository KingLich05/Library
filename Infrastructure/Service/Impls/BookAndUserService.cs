using sultan.Web;

namespace sultan.Service.Impls;

public class BookAndUserService : IBookAndUserService
{
    private static Context _db = new Context();
    public Task<List<BookAndUser>> GetBau()
    {
        var bau = _db.BookAndUsers.ToList();
        return Task.FromResult(bau);
    }

    public async Task AddBook(int bookId, int userId)
    {
        BookAndUser addTemp = new BookAndUser { idUser = userId, idBook = bookId, Term = DateTime.Now };
        _db.BookAndUsers.Add(addTemp);
        await _db.SaveChangesAsync();
    }

    public async Task ReturnBook(int bookId, int userId)
    {
        var bau = await GetBau();
        BookAndUser? deleteBook = bau.FirstOrDefault(b => b.idBook == bookId && userId == b.idUser);
        _db.BookAndUsers.Remove(deleteBook!);
        await _db.SaveChangesAsync();
    }

    public async Task MailService()
    {
        await Mail.SendMail();
    }
}