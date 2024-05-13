namespace sultan.Service;

public abstract class IBookService
{
    public abstract Task<List<Books>> GetBook();
    public abstract Task<List<Books>> FillLibrary();
}