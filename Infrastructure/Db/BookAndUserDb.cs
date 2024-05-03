namespace sultan.Db;

public class BookAndUserDb
{
    private static Context _db = new Context();

    public static List<BookAndUser> GetBau()
    {
        var bau = _db.BookAndUsers.ToList();
        return bau;
    }

    public static void AddBook(int bookId, int userId)
    {
        var bau = GetBau();
        BookAndUser addTemp = new BookAndUser { idUser = userId, idBook = bookId, Term = DateTime.Now };
        // bool checkExist = true;
        // foreach (var b in bau)
        // {
        //     if (addTemp.idUser == b.idUser && addTemp.idBook == b.idBook)
        //     {
        //         checkExist = false;
        //     }
        // }
        // if (checkExist == true)
        // {
        //     _db.BookAndUsers.Add(addTemp);
        //     _db.SaveChanges();
        // }
        _db.BookAndUsers.Add(addTemp);
        _db.SaveChanges();
        bau = GetBau();
    }

    public static void ReturnBook(int bookId)
    {
        
    }
}