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
    internal class BuyersViewModel : ViewModel
    {
        public IRepository<Buyer> BuyerRepository { get; }

        public BuyersViewModel(IRepository<Buyer> buyerRepository)
        {
            BuyerRepository = buyerRepository;
        }
    }
}
