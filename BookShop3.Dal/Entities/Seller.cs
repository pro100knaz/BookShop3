using BookShop3.Dal.Entities.Base;

namespace BookShop3.Dal.Entities;

public class Seller : Person
{
    public override string ToString() => $"Продавец {Surname} {Name} {Patronymic}";
}