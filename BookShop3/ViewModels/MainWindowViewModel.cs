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
    public class MainWindowViewModel : ViewModel
    {
        public IRepository<Book> Books { get; }

        public MainWindowViewModel(IRepository<Book> books)
        {
            Books = books;

            var x = books.Items.Take(10).ToArray();
        }
    }
}
