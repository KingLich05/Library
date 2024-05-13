using Microsoft.EntityFrameworkCore;
using sultan.Web;

namespace sultan.Service.Impls;

public class BookAndUserService : IBookAndUserService
{
    private static readonly Context Db = new Context();
    public Task<List<BookAndUser?>> GetBau()
    {
        var bau = Db.BookAndUsers.ToList();
        return Task.FromResult(bau);
    }

    public async Task AddBook(int bookId, int userId)
    {
        BookAndUser addTemp = new BookAndUser { idUser = userId, idBook = bookId, Term = DateTime.Now };
        Db.BookAndUsers.Add(addTemp);
        await Db.SaveChangesAsync();
    }

    public async Task ReturnBook(int bookId, int userId)
    {
        var bau = await GetBau();
        BookAndUser? deleteBook = bau.FirstOrDefault(b => b.idBook == bookId && userId == b.idUser);
        Db.BookAndUsers.Remove(deleteBook!);
        await Db.SaveChangesAsync();
    }

    public async Task<List<sultan.Temp?>> GetBauOnlyPerson(int userId)
    {
        Db.Temps.RemoveRange(Db.Temps);
        await Db.SaveChangesAsync();
        
        var bau = await GetBau();
        IBookService bookService = new BookService();
        var books = await bookService.GetBook();
        
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
            var temp = Db.Temps.ToList();
        }
        catch (Exception e)
        { }
        await Db.SaveChangesAsync();
        var tempList = Db.Temps.ToListAsync();
        return await tempList;
    }
    
    public async Task MailService()
    {
        await Mail.SendMail();
    }
}