using BookShop3.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop3.Dal.Context
{
    public class BookShopDB : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Deal> Deals { get; set; }

        public BookShopDB(DbContextOptions<BookShopDB> options) : base(options)
        {

        }

    }
}
