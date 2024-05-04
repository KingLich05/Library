namespace sultan.Service;

public interface IBookService
{
    Task<List<Books>> GetBook();
    Task<List<Books>> FillLibrary();
}