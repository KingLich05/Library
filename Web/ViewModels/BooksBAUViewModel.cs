using sultan.Domain.Models;

namespace sultan.Web.ViewModels;

public class BooksBAUViewModel
{
    public List<Books> Books { get; set; }
    public List<Temp> Temps { get; set; }
    public int idUser { get; set; }
}