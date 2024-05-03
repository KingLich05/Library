namespace sultan.Service;

public class BooksServices : Context
{
    private static Context _db = new Context();

    public async static Task<List<Books>> GetBook()
    {
        var books = _db.Books.ToList();
        return books;
    }
    
    public async Task<List<Books>> FillLibrary()
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
        _db.Books.AddRange(books);
        await _db.SaveChangesAsync();
        return await GetBook();
    }
}