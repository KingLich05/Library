namespace sultan.Web.ViewModels;

public class BooksBAUViewModel
{
    public List<sultan.Books> Books { get; set; }
    public List<BookAndUser> BookAndUser { get; set; }
    public int idUser { get; set; }
}