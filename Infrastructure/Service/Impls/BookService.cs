using Microsoft.EntityFrameworkCore;

namespace sultan.Service.Impls;

public class BookService : IBookService
{
    private static readonly Context Db = new Context();

    public override async Task<List<Books>> GetBookAsync()
    {   
        return await Db.Books.ToListAsync();
    }
    
    public override async Task<List<Books>> FillLibrary()
    {
        List<Books> books = new List<Books>
        {
            new Books {Name = "Путь Абая", Author = "Мухтар Ауэзов", Presence = 3},
            new Books {Name = "Бегущий за ветром", Author = "Халед Хоссейни", Presence = 4},
            new Books {Name = "Раскол", Author = "Кристи Голден" , Presence = 1},
            new Books {Name = "кровью и честью", Author = "Крис Мэтцен", Presence = 10},
            new Books {Name = "Путешествие к центру Земли", Author = "Жюль Верн", Presence = 5},
            new Books {Name = "Python для чайников", Author = "Мюллер", Presence = 7},
            new Books {Name = "По ту сторону темного портала",  Author = "Кристи Голден", Presence = 3},
            new Books {Name = "Преступление и наказание", Author = "Достоевский", Presence = 5},
            new Books {Name = "Богатый папа бедный папа", Author = "Роберт Кийосаки", Presence = 7},
            new Books {Name = "Великий Гэтсби",  Author = "Фрэнсис Скотт", Presence = 1},
            new Books {Name = "7 навыков высокоэффективных людей",  Author = "Стивен Кови", Presence = 10 },
            new Books {Name = "Тысяча сияющих солнц", Author = "Халед Хоссейни", Presence = 4 }
        };
        Db.Books.AddRange(books);
        await Db.SaveChangesAsync();
        return await GetBookAsync();
    }
}