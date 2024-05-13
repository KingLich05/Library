using System.ComponentModel.DataAnnotations;
using sultan.Domain.Models;

namespace sultan;
public class Temp : Entity
{
    [Key]
    public string Name { get; set; }
    public int idP { get; set; } 
    public int idB{ get; set; }
    public string Author { get; set; }
    public DateTime Time { get; set; }
}