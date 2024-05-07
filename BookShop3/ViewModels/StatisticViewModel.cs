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
    internal class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<Buyer> _buyerRepository;
        private readonly IRepository<Seller> _sellerRepository;

        public StatisticViewModel(IRepository<Book> booksRepository, IRepository<Buyer> buyerRepository, IRepository<Seller> sellerRepository)
        {
            _booksRepository = booksRepository;
            _buyerRepository = buyerRepository;
            _sellerRepository = sellerRepository;
        }
    }
}
