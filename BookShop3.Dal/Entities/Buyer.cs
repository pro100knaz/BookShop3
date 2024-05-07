using BookShop3.Dal.Entities.Base;

namespace BookShop3.Dal.Entities;

public class Buyer : Person
{
    public override string ToString() => $"Покупатель {Surname} {Name} {Patronymic}";
}