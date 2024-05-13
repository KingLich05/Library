using Microsoft.EntityFrameworkCore;

namespace sultan.Service.Impls;

public class BookService : IBookService
{
    private static readonly Context Db = new Context();

    public override async Task<List<Books>> GetBook()
    {   
        return await Db.Books.ToListAsync();
    }
    
    public override async Task<List<Books>> FillLibrary()
    {
        List<Books> books = new List<Books>
        {
            new Books {Name = "Путь Абая", Author = "Мухтар Ауэзов"},
            new Books {Name = "Бегущий за ветром", Author = "Халед Хоссейни"},
            new Books {Name = "Раскол", Author = "Кристи Голден" },
            new Books {Name = "кровью и честью", Author = "Крис Мэтцен"},
            new Books {Name = "Путешествие к центру Земли", Author = "Жюль Верн"},
            new Books {Name = "Python для чайников", Author = "Мюллер"},
            new Books {Name = "По ту сторону темного портала",  Author = "Кристи Голден" },
            new Books {Name = "Преступление и наказание", Author = "Достоевский"},
            new Books {Name = "Богатый папа бедный папа", Author = "Роберт Кийосаки"},
            new Books {Name = "Великий Гэтсби",  Author = "Фрэнсис Скотт"},
            new Books {Name = "7 навыков высокоэффективных людей",  Author = "Стивен Кови" },
            new Books {Name = "Тысяча сияющих солнц", Author = "Халед Хоссейни" }
        };
        Db.Books.AddRange(books);
        await Db.SaveChangesAsync();
        return await GetBook();
    }
}