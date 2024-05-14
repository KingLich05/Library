using sultan.Domain.Models;

namespace sultan.Service;

public abstract class IBookService
{
    public abstract Task<List<Books>> GetBookAsync();
    public abstract Task<List<Books>> FillLibrary();
}