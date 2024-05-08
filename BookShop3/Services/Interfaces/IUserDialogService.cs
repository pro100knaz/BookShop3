using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop3.Dal.Entities;

namespace BookShop3.Services.Interfaces
{
	internal interface IUserDialogService
	{
		bool Edit(Book book);
	}
}
