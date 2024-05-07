using BookShop3.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop3.Services.Interfaces
{
    public interface ISalesService
    { 
        IEnumerable<Deal> Deals { get;}
        Task<Deal> MakeADeal(string BookName, Seller seller, Buyer buyer, decimal Price);
    }
}
