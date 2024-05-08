using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;
using BookShop3.Infrastructure.DebugServices;
using BookShop3.Services.Interfaces;
using MathCore.WPF;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookShop3.ViewModels
{
    internal class BooksViewModel : ViewModel
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly IUserDialogService _userDialog;

        #region ObservableCollection<Book> Books - "Книги"
        ///<summary> Книги </summary>
        private ObservableCollection<Book> _Books;
        ///<summary> Книги </summary>
        public ObservableCollection<Book> Books
        {
            get => _Books;
            set
            {
                if (Set(ref _Books, value))
                {
                    _BooksViewSort.Source = value;
                    OnPropertyChanged(nameof(BooksView));
                    BooksView.Refresh();
                    if (!App.IsDesignTime)
                    {
                    }

                }
            }
        }

        #endregion


        #region Book SelectedBook - "             Выбранная книга"

        ///<summary>              Выбранная книга </summary>
        private Book _SelectedBook;

        ///<summary>              Выбранная книга </summary>
        public Book SelectedBook
        {
            get => _SelectedBook;
            set => Set(ref _SelectedBook, value);
        }

        #endregion

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
                if (BooksView != null)
                {
                    BooksView.Refresh();
                }

            }
        }

        #endregion

        private CollectionViewSource _BooksViewSort;

        public ICollectionView BooksView => _BooksViewSort.View;

        #region Command LoadDataCommand - Загрузка данных

        ///<summary> Загрузка данных </summary>
        private ICommand _LoadDataCommand;

        ///<summary> Загрузка данных </summary>
        public ICommand LoadDataCommand => _LoadDataCommand ??=
            new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        ///<summary>Проверка возможности выполнения - Загрузка данных </summary>
        private bool CanLoadDataCommandExecute() => true;

        ///<summary>Логика выполнения - Загрузка данных </summary>
        private async void OnLoadDataCommandExecuted()
        {
            Books = (await _booksRepository.Items.ToArrayAsync()).ToObservableCollection();
        }

        #endregion

        #region Command AddNewBookCommand - Добавление книги

        ///<summary> Добавление книги </summary>
        private ICommand _AddNewBookCommand;

        ///<summary> Добавление книги </summary>
        public ICommand AddNewBookCommand => _AddNewBookCommand ??=
            new LambdaCommand(OnAddNewBookCommandExecuted, CanAddNewBookCommandExecute);

        ///<summary>Проверка возможности выполнения - Добавление книги </summary>
        private bool CanAddNewBookCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Добавление книги </summary>
        private void OnAddNewBookCommandExecuted(object p)
        {
            var new_book = new Book();

            if(!_userDialog.Edit(new_book)) 
                return;

            Books.Add( _booksRepository.Add(new_book));

            SelectedBook = new_book;

        }

        #endregion

        #region Command DeleteSelectedBookCommand - Удаление выбранной книги

        ///<summary> Удаление выбранной книги </summary>
        private ICommand _DeleteSelectedBookCommand;

        ///<summary> Удаление выбранной книги </summary>
        public ICommand DeleteSelectedBookCommand => _DeleteSelectedBookCommand ??=
            new LambdaCommand(OnDeleteSelectedBookCommandExecuted, CanDeleteSelectedBookCommandExecute);

        ///<summary>Проверка возможности выполнения - Удаление выбранной книги </summary>
        private bool CanDeleteSelectedBookCommandExecute(object p) => p != null || SelectedBook != null;

        ///<summary>Логика выполнения - Удаление выбранной книги </summary>
        private void OnDeleteSelectedBookCommandExecuted(object p)
        {

            if(!(p is Book book)) return;

            var book_to_remove = book ?? SelectedBook;


            if(!_userDialog.ConfirmWarning($"Вы хотите удалить книгу{book_to_remove.Name} ?", "Book Deleting")) return;


            _booksRepository.Remove(book_to_remove.Id);
            Books.Remove(book_to_remove);

            if (ReferenceEquals(SelectedBook, book_to_remove))
                SelectedBook = null;


        }

        #endregion


        public BooksViewModel()
            :this(new DebugBookRepository(), null)
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Это отладлчный конструктор лдя тестов");
            //OnLoadDataCommandExecuted();
            _BooksViewSort.Source = _booksRepository.Items.ToArray();
        }

        public BooksViewModel(IRepository<Book> booksRepository, IUserDialogService userDialog)
        {
            _booksRepository = booksRepository;
            _userDialog = userDialog;

            _BooksViewSort = new CollectionViewSource()
            {
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
