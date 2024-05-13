
namespace sultan.Service.Impls;

public class Temp : ITemp
{
    private static readonly Context Db = new Context();
    public async void GetListAsync()
    {
        
        IBookAndUserService bauser = new BookAndUserService();
        IBookService bookser = new BookService();
        var bau = await bauser.GetBau();
        var books = await bookser.GetBook();
        
        var temporary = from b in bau 
            join i in books on b.idBook equals i.Id
            select new {idP = b.idUser, idB = b.idBook, Name = i.Name, Author = i.Author, Time = b.Term };
        var selectedPerson = from b in temporary
            where b.idP == 1
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
        {
            // ignored
        }
    }
}
    
// app.MapGet("/api/profileBook", () => temp);
