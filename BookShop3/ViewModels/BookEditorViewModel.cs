using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop3.Dal.Entities;
using MathCore.WPF.ViewModels;

namespace BookShop3.ViewModels
{
    class BookEditorViewModel : ViewModel
    {

        #region int BookId - "BookId"
        public int BookId
        {
            get;
        }

        #endregion

        #region string Name - "summary"

        ///<summary> summary </summary>
        private string _Name;

        ///<summary> summary </summary>
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        #endregion



        public BookEditorViewModel() : this(new Book(){Name = "aRE you GAY >?<"})
        {
            if (!App.IsDesignTime)
                throw new InvalidCastException("NO FOR RUNtIME");

        }

        public BookEditorViewModel(Book book)
        {
            Name = book.Name;
            BookId = book.Id;
        }


    }
}
