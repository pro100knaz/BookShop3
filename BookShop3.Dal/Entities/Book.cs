using BookShop3.Dal.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop3.Dal.Entities
{
    public class Book : NamedEntity
    {
        public Category Category { get; set; }

        public override string ToString() => $"Книга {Name}";
    }
}
