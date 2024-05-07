using BookShop3.Dal.Context;
using BookShop3.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop3.Dal;

class BooksRepository : DbRepository<Book>
{
    public override IQueryable<Book> Items => base.Items.Include(item => item.Category);

    public BooksRepository(BookShopDB db) : base(db) { }
}