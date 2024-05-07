using BookShop3.Dal.Context;
using BookShop3.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop3.Dal;

class DealsRepository : DbRepository<Deal>
{
    public override IQueryable<Deal> Items => base.Items
        .Include(item => item.Book)
        .Include(item => item.Seller)
        .Include(item => item.Buyer)
    ;

    public DealsRepository(BookShopDB db) : base(db) { }
}