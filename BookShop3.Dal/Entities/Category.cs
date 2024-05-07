using BookShop3.Dal.Entities.Base;

namespace BookShop3.Dal.Entities;

public class Category : NamedEntity
{
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();

    public override string ToString() => $"Категория {Name}";
}