using Model.Class;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IBookDAO
    {
        IEnumerable<Book> GetAllBookAuthors();
        IEnumerable<Book> GetBookByID(int id);
        int Insert(Book bk);
        bool Update(Book bk);
        bool Delete(Book bk);
        List<BookAuthor> GetBookViewModel();

    }
}
