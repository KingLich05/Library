namespace sultan.Service;

public class BookAndUsersServices
{
    private static Context _db = new Context();

    public static Task<List<BookAndUser>> GetBau()
    {
        var bau = _db.BookAndUsers.ToList();
        return Task.FromResult(bau);
    }

    public static async void AddBook(int bookId, int userId)
    {
        
        BookAndUser addTemp = new BookAndUser { idUser = userId, idBook = bookId, Term = DateTime.Now };
        _db.BookAndUsers.Add(addTemp);
        await _db.SaveChangesAsync();
    }

    public static async void ReturnBook(int bookId, int userId)
    {
        var bau = await GetBau();
        BookAndUser? deleteBook = bau.FirstOrDefault(b => b.idBook == bookId && userId == b.idUser);
        _db.BookAndUsers.Remove(deleteBook);
        await _db.SaveChangesAsync();
    }
}