using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;
using BookShop3.Models;
using BookShop3.Service;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookShop3.ViewModels
{
    internal class StatisticViewModel : ViewModel
    {
        public ObservableCollection<BestSellerInfo> BestSellers { get; } = new ObservableCollection<BestSellerInfo>();


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
            await ComputeDealsStatistic();
        }

        private async Task ComputeDealsStatistic()
        {
            var _deals = _dealsRepository.Items;

            var bestsellers =  _deals
                .GroupBy(deal => deal.Book)
                .Select(book_deals => new BestSellerInfo()
                    { Book = book_deals.Key, SellCount = book_deals.Count(), SumCost = book_deals.Sum(d => d.Price) })
                .OrderByDescending(book => book.SellCount)
                .Take(5);

            //var bestsellers2 = _deals
            //    .GroupBy(deal => deal.Book.Id)
            //    .Select(deals => new { BookId = deals.Key, Count = deals.Count(), Sum = deals.Sum(d => d.Price) })
            //    .OrderByDescending(deals => deals.Count)
            //    .Take(5)
            //    .Join(_booksRepository.Items,
            //        deals => deals.BookId,
            //        book => book.Id,
            //        (deals, book) => new BestSellerInfo()
            //        {
            //            Book = book,
            //            SellCount = deals.Count,
            //            SumCost = deals.Sum
            //        });


            BestSellers.AddClear(await bestsellers.ToArrayAsync());

            //foreach (var bestSeller in await bestsellers2.ToArrayAsync())
            //{
            //    BestSellers.Add(bestSeller);
            //}
        }

        #endregion


        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<Buyer> _buyerRepository;
        private readonly IRepository<Seller> _sellerRepository;
        private readonly IRepository<Deal> _dealsRepository;

        public StatisticViewModel(IRepository<Book> booksRepository, IRepository<Buyer> buyerRepository,
            IRepository<Seller> sellerRepository, IRepository<Deal> dealsRepository)
        {
            _booksRepository = booksRepository;
            _buyerRepository = buyerRepository;
            _sellerRepository = sellerRepository;
            _dealsRepository = dealsRepository;
        }
    }
}