using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;
using BookShop3.Infrastructure.DebugServices;
using MathCore.WPF.ViewModels;

namespace BookShop3.ViewModels
{
    internal class BooksViewModel : ViewModel
    {
        private readonly IRepository<Book> _booksRepository;


        #region string BooksFilter - "Искомое Слово"

        ///<summary> Искомое Слово </summary>
        private string _BooksFilter;

        ///<summary> Искомое Слово </summary>
        public string BooksFilter
        {
            get => _BooksFilter;
            set
            {
                if(Set(ref _BooksFilter, value));
                _BooksViewSort.View.Refresh();

            }
        }

        #endregion

        private CollectionViewSource _BooksViewSort;
        public ICollectionView BooksView => _BooksViewSort.View;
        public IEnumerable<Book> Books  => _booksRepository.Items.ToArray();

        public BooksViewModel()
            :this(new DebugBookRepository())
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Это отладлчный конструктор лдя тестов");

        }

        public BooksViewModel(IRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;

            _BooksViewSort = new CollectionViewSource()
            {
                Source = Books,
                SortDescriptions =
                {
                    new SortDescription(nameof(Book.Name), ListSortDirection.Ascending)
                }
            };

            _BooksViewSort.Filter += OnBooksFilter; //для каждого элеммента и передаёт книгк
        }

        private void OnBooksFilter(object sender, FilterEventArgs e)
        {
            if(!(e.Item is Book book) || string.IsNullOrEmpty(BooksFilter)) return;

            if (!book.Name.Contains(_BooksFilter))
                e.Accepted = false;
        }
    }
}
