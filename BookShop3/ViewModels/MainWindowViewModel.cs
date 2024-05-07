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
        #region string Title - "Имя заголовка"

        ///<summary> Имя заголовка </summary>
        private string _Title = "Работа с Entity Framework";

        ///<summary> Имя заголовка </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion
        public IRepository<Book> Books { get; }

        public MainWindowViewModel(IRepository<Book> books)
        {
            Books = books;

            var bookss = books.Items.Take(10).ToArray();
        }
    }
}
