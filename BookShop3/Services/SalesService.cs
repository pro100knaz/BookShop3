using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;
using BookShop3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop3.Services
{
    internal class SalesService : ISalesService
    {
        private readonly IRepository<Book> _books;
        private readonly IRepository<Deal> _deals;


        public IEnumerable<Deal> Deals => _deals.Items;


        public SalesService(
            IRepository<Book> Books,
            IRepository<Deal> Deals)
        {
            _books = Books;
            _deals = Deals;
        }

        public async Task<Deal> MakeADeal(string BookName, Seller seller, Buyer buyer, decimal Price)
        {
            var book = await _books.Items.FirstOrDefaultAsync(b => b.Name == BookName).ConfigureAwait(false);
            if (book == null)
            {
                return null;
            }

            var deal = new Deal
            {
                Book = book,
                Seller = seller,
                Buyer = buyer,
                Price = Price

            };

            return await _deals.AddAsync(deal);

        }

    }
}
