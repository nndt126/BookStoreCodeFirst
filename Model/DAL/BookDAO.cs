using Model.Class;
using Model.Interface;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class BookDAO : IBookDAO
    {
        private readonly IBookStoreIdentityDbContext _iBookStoreIdentityDbContext;

        public BookDAO(IBookStoreIdentityDbContext iBookStoreIdentityDbContext)
        {
            _iBookStoreIdentityDbContext = iBookStoreIdentityDbContext;
        }

        public IEnumerable<Book> GetAllBookAuthors()
        {
            return _iBookStoreIdentityDbContext.Books;
        }

        public Book GetBook()
        {
            return _iBookStoreIdentityDbContext.Books.FirstOrDefault();
        }
       

        public IEnumerable<Book> GetBookByID(int id)
        {
            var result = _iBookStoreIdentityDbContext.Books.Where(n => n.ID == id);
            return result;
        }

        public int Insert(Book bk)
        {
            var result = _iBookStoreIdentityDbContext.Books.Add(bk);
            _iBookStoreIdentityDbContext.SaveChanges();
            return result.ID;
        }

        public bool Update(Book bk)
        {
            try
            {
                _iBookStoreIdentityDbContext.SetModified(bk);
                _iBookStoreIdentityDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Delete(Book bk)
        {
            try
            {
                bk.IsDeleted = true;
                _iBookStoreIdentityDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public List<BookAuthor> GetBookViewModel()
        {
            //var model = db.Books.ToList();
            var model = (from a in _iBookStoreIdentityDbContext.Books
                         join b in _iBookStoreIdentityDbContext.Authors
                         on a.AuthorID equals b.ID
                         where a.IsDeleted == false
                         select new
                         {
                             Name = a.Name,
                             Prices = a.Prices,
                             Description = a.Description,
                             Image  = a.Image,
                             AuthorName = b.AuthorName,
                         }).AsEnumerable().Select(x => new BookAuthor()
                         {
                             BookName = x.Name,
                             Prices = x.Prices,
                             Description = x.Description,
                             Image = x.Image,
                             AuthorName = x.AuthorName,
                         });
            return model.ToList();
        }
    }
}
