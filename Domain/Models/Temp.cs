using System.ComponentModel.DataAnnotations;

namespace sultan;
public class Temp
{
    [Key]
    public string Name { get; set; }
    public int idP { get; set; } 
    public int idB{ get; set; }
    public string Author { get; set; }
    public DateTime Time { get; set; }
}