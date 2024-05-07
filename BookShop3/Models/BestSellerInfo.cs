using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop3.Dal.Entities;

namespace BookShop3.Models
{
    internal class BestSellerInfo
    {
        public Book Book { get; set; }

        public int SellCount { get; set; }
    }
}
