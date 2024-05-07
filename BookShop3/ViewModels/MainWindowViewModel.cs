using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookShop.Interfaces;
using BookShop3.Dal.Entities;
using BookShop3.Services.Interfaces;
using MathCore.WPF.Commands;
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


        #region ViewModel CurrentModel - "Представление текущей модели(дочерняя)"

        ///<summary> Представление текущей модели(дочерняя) </summary>
        private ViewModel _CurrentModel;

        ///<summary> Представление текущей модели(дочерняя) </summary>
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            set => Set(ref _CurrentModel, value);
        }

        #endregion



        #region Command ShowBooksViewCommand - Отобразить представление книг

        ///<summary> Отобразить представление книг </summary>
        private ICommand _ShowBooksViewCommand;

        ///<summary> Отобразить представление книг </summary>
        public ICommand ShowBooksViewCommand => _ShowBooksViewCommand ??=
            new LambdaCommand(OnShowBooksViewCommandExecuted, CanShowBooksViewCommandExecute);

        ///<summary>Проверка возможности выполнения - Отобразить представление книг </summary>
        private bool CanShowBooksViewCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Отобразить представление книг </summary>
        private void OnShowBooksViewCommandExecuted(object p)
        {

            CurrentModel = new BooksViewModel(_booksRepository);
        }

        #endregion

        #region Command ShowBuyersViewModelCommand - Представление покупателей

        ///<summary> Представление покупателей </summary>
        private ICommand _ShowBuyersViewModelCommand;

        ///<summary> Представление покупателей </summary>
        public ICommand ShowBuyersViewModelCommand => _ShowBuyersViewModelCommand ??=
            new LambdaCommand(OnShowBuyersViewModelCommandExecuted, CanShowBuyersViewModelCommandExecute);

        ///<summary>Проверка возможности выполнения - Представление покупателей </summary>
        private bool CanShowBuyersViewModelCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Представление покупателей </summary>
        private void OnShowBuyersViewModelCommandExecuted(object p)
        {
            CurrentModel = new BuyersViewModel(_buyerRepository);
        }

        #endregion

        #region Command ShowStatisticViewCommand - Представление статистики

        ///<summary> Представление статистики </summary>
        private ICommand _ShowStatisticViewCommand;

        ///<summary> Представление статистики </summary>
        public ICommand ShowStatisticViewCommand => _ShowStatisticViewCommand ??=
            new LambdaCommand(OnShowStatisticViewCommandExecuted, CanShowStatisticViewCommandExecute);

        ///<summary>Проверка возможности выполнения - Представление статистики </summary>
        private bool CanShowStatisticViewCommandExecute(object p) => true;

        ///<summary>Логика выполнения - Представление статистики </summary>
        private void OnShowStatisticViewCommandExecuted(object p)
        {
            CurrentModel = new StatisticViewModel(
                    _booksRepository,
                    _buyerRepository,
                    _sellerRepository,
                    _dealRepository
                );
        }

        #endregion




        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<Buyer> _buyerRepository;
        private readonly IRepository<Seller> _sellerRepository;
        private readonly IRepository<Deal> _dealRepository;
        private readonly ISalesService _salesService;

        public MainWindowViewModel(
            IRepository<Book> BooksRepository,
            IRepository<Buyer> BuyerRepository,
            IRepository<Seller> SellerRepository,
            IRepository<Deal> DealRepository,
            ISalesService salesService)
        {
            _booksRepository = BooksRepository;
            _buyerRepository = BuyerRepository;
            _sellerRepository = SellerRepository;
            _dealRepository = DealRepository;
            _salesService = salesService;


        }


        //private async void Test()
        //{

        //    var deals_counts = _salesService.Deals.Count();
        //    var book = await _booksRepository.GetAsync(5);
        //    var buyer = await _buyerRepository.GetAsync(3);
        //    var seller = await _sellerRepository.GetAsync(4);

        //    _salesService.MakeADeal(book.Name, seller, buyer, 100);

        //    var deals_counts2 = _salesService.Deals.Count();

        //}

    }
}
