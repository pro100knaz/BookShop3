using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;
using MathCore.WPF.ViewModels;

namespace BookShop3.ViewModels
{
    internal class BooksViewModel : ViewModel
    {
        private readonly IRepository<Book> _booksRepository;

        public BooksViewModel(IRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }
    }
}
