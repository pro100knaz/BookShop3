using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop3.Dal.Entities;
using BookShop3.Services.Interfaces;
using BookShop3.View.Windows;
using BookShop3.ViewModels;

namespace BookShop3.Services
{
    class UserDialogService : IUserDialogService
    {
        public bool Edit(Book book)
        {
            var book_editor_model = new BookEditorViewModel(book);

            var book_editor_window = new BookEditorWindow()
            {
                DataContext = book_editor_model
            };


            if(book_editor_window.ShowDialog() != true ) return false;

            book.Name = book_editor_model.Name;

            return true;
        }
    }
}
