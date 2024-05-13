using Microsoft.EntityFrameworkCore;
using sultan.Web;

namespace sultan.Service.Impls;

public class BookAndUserService : IBookAndUserService
{
    
    private readonly IBookService _bookService;

    public BookAndUserService(IBookService bookService)
    {
        _bookService = bookService;
    }
    private static readonly Context Db = new Context();

    public BookAndUserService()
    {
        throw new NotImplementedException();
    }

    public async Task<List<BookAndUser>> GetBau()
    {
        return await Db.BookAndUsers.ToListAsync();
    }

    public async Task<bool> AddBook(int bookId, int userId)
    {
        bool check = await Presence(bookId);
        if (check)
        {
            var books = await _bookService.GetBookAsync();
            
            Books? book = Db.Books.FirstOrDefault(b => b.Id == bookId);
            book!.Presence -= 1;
            books[bookId - 1].Presence -= 1;
            BookAndUser addTemp = new BookAndUser { idUser = userId, idBook = bookId, Term = DateTime.Now };
            Db.BookAndUsers.Add(addTemp);
            await Db.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
       
    }

    public async Task<bool> Presence(int bookId)
    {
        var books = await _bookService.GetBookAsync();
        if (books[bookId - 1].Presence > 0)
        {
            return true;
        }
        return false;
    }

    public async Task ReturnBook(int bookId, int userId)
    {
        var bau = await GetBau();
        var books = await _bookService.GetBookAsync();
        
        Books? book = Db.Books.FirstOrDefault(b => b.Id == bookId);
        book!.Presence += 1;
        
        books[bookId - 1].Presence += 1; 
        
        BookAndUser? deleteBook = bau.FirstOrDefault(b => b.idBook == bookId && userId == b.idUser);
        Db.BookAndUsers.Remove(deleteBook!);
        await Db.SaveChangesAsync();
    }

    public async Task<List<sultan.Temp>> GetBauOnlyPerson(int userId)
    {
        Db.Temps.RemoveRange(Db.Temps);
        await Db.SaveChangesAsync();
        
        var bau = await GetBau();
        IBookService bookService = new BookService();
        var books = await bookService.GetBookAsync();
        
        var temporary = from b in bau 
            join i in books on b.idBook equals i.Id
            select new {idP = b.idUser, idB = b.idBook, Name = i.Name, Author = i.Author, Time = b.Term };
        var selectedPerson = from b in temporary
            where b.idP == userId
            select b;
        try
        {    foreach (var emp in selectedPerson)
            {   
                DateTime time = emp.Time;
                var t = new sultan.Temp { idB = emp.idB, idP = emp.idP, Author = emp.Author, Name = emp.Name, Time = time };
                Db.Temps.Add(t);
            }
            await Db.SaveChangesAsync();
            var temp = Db.Temps.ToListAsync();
        }
        catch (Exception e)
        { }
        await Db.SaveChangesAsync();
        return await Db.Temps.ToListAsync();
    }
    
    public async Task MailService()
    {
        await Mail.SendMail();
    }
}