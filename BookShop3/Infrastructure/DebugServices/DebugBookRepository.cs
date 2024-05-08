using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;

namespace BookShop3.Infrastructure.DebugServices
{
    class DebugBookRepository : IRepository<Book>
    {
        public DebugBookRepository()
        {
           var Books = Enumerable
                .Range(1, 100)
                .Select(i => new Book()
                {
                    Id = i,
                    Name =  $"Кника {i}",
                    //Category = new Category( )
                    //{
                    //    Id = 0,
                    //    Name = "Хорроры"
                    //}
                })
                .ToArray();
           var categories = Enumerable.Range(1, 10)
               .Select(i => new Category()
               {
                   Id = i,
                   Name = $"Хорроры {i}"
               })
               .ToArray();

           foreach (var book in Books)
           {
               var category = categories[book.Id % categories.Length];
               category.Books.Add(book);
               book.Category = category;

           }

           Items = Books.AsQueryable();
        }


        public IQueryable<Book> Items { get; }



        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Book Add(Book item)
        {
            throw new NotImplementedException();
        }

        public Task<Book> AddAsync(Book item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(Book item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
