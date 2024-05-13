using sultan.Domain.Models;

namespace sultan;

public class BookAndUser : Entity
{
    public int idBook { get; set; }
    public int idUser { get; set; }
    public DateTime Term { get; set; }
}