using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookShop3.ViewModels
{
    internal class StatisticViewModel : ViewModel
    {

            #region int BooksCount - "Количество книг"

        ///<summary> Количество книг </summary>
        private int _BooksCount;

        ///<summary> Количество книг </summary>
        public int BooksCount
        {
            get => _BooksCount;
            set => Set(ref _BooksCount, value);
        }

        #endregion


        #region Command ComputeStatisticCommand - Вычисление статистических данных

        ///<summary> Вычисление статистических данных </summary>
        private ICommand _ComputeStatisticCommand;

        ///<summary> Вычисление статистических данных </summary>
        public ICommand ComputeStatisticCommand => _ComputeStatisticCommand ??=
            new LambdaCommand(OnComputeStatisticCommandExecuted, CanComputeStatisticCommandExecute);

        ///<summary>Проверка возможности выполнения - Вычисление статистических данных </summary>
        private bool CanComputeStatisticCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Вычисление статистических данных </summary>
        private async void OnComputeStatisticCommandExecuted(object p)
        {
            BooksCount = await _booksRepository.Items.CountAsync();

            var deals =  _dealsRepository.Items;

            var bestsellers = await deals.GroupBy(deal => deal.Book)
            .Select(book_deals => new { Book = book_deals.Key, Count = book_deals.Count() })
            .OrderByDescending(book => book.Count)
            .Take(5)
            .ToArrayAsync();
        }

        #endregion




        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<Buyer> _buyerRepository;
        private readonly IRepository<Seller> _sellerRepository;
        private readonly IRepository<Deal> _dealsRepository;

        public StatisticViewModel(IRepository<Book> booksRepository, IRepository<Buyer> buyerRepository, IRepository<Seller> sellerRepository, IRepository<Deal> dealsRepository)
        {
            _booksRepository = booksRepository;
            _buyerRepository = buyerRepository;
            _sellerRepository = sellerRepository;
            _dealsRepository = dealsRepository;
        }
    }
}
