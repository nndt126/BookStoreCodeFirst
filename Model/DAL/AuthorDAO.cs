using Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Model.Interface;

namespace Model.DAL
{
    public class AuthorDAO : IAuthorDAO
    {
        private readonly IBookStoreIdentityDbContext _iBookStoreIdentityDbContext;
        //public AuthorDAO()
        //{
        //    _iBookStoreIdentityDbContext = new BookStoreIdentityDbContext();
        //}

        public AuthorDAO(IBookStoreIdentityDbContext iBookStoreIdentityDbContext)
        {
            _iBookStoreIdentityDbContext = iBookStoreIdentityDbContext;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _iBookStoreIdentityDbContext.Authors;
        }


        public List<Author> GetAllAuthorsAdmin()
        {
            return _iBookStoreIdentityDbContext.Authors.ToList();
        }

        public List<Author> GetAuthorPaging(string sortOrder, string searchString,int numberItem, int pageSize)
        {
            List<Author> authors;

            if (!String.IsNullOrEmpty(searchString))
            {
                authors = _iBookStoreIdentityDbContext.Authors.Where(s => s.AuthorName.Contains(searchString)).ToList();
            }
            else
            {
                switch (sortOrder)
                {
                    case "name_desc":
                        authors = _iBookStoreIdentityDbContext.Authors.OrderByDescending(s => s.AuthorName).Skip((pageSize - 1) * numberItem).Take(numberItem).ToList();
                        break;
                    case "Date":
                        authors = _iBookStoreIdentityDbContext.Authors.OrderByDescending(s => s.Birthday).Skip((pageSize - 1) * numberItem).Take(numberItem).ToList();
                        break;
                    case "date_desc":
                        authors = _iBookStoreIdentityDbContext.Authors.OrderByDescending(s => s.Birthday).Skip((pageSize - 1) * numberItem).Take(numberItem).ToList();
                        break;
                    default:
                        authors = _iBookStoreIdentityDbContext.Authors.OrderByDescending(s => s.AuthorName).Skip((pageSize - 1) * numberItem).Take(numberItem).ToList();
                        break;
                }
            }
            //var authors = db.Authors.OrderBy(author => author.ID).Skip((pageSize - 1) * numberItem).Take(numberItem).ToList();
            return authors;
        }

        public List<Author> GetAuthors()
        {
            return _iBookStoreIdentityDbContext.Authors.Where(x => x.IsDeleted == false).ToList();
        }

        public int Insert(Author au)
        {
            _iBookStoreIdentityDbContext.Authors.Add(au);
            _iBookStoreIdentityDbContext.SaveChanges();
            return au.ID;
        }

        public Author GetAuthorByID(int? id)
        {
            return _iBookStoreIdentityDbContext.Authors.Find(id);
        }

        public bool Update(Author author)
        {
            try
            {
                _iBookStoreIdentityDbContext.SetModified(author);
                _iBookStoreIdentityDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var au = _iBookStoreIdentityDbContext.Authors.Find(id);
                _iBookStoreIdentityDbContext.Authors.Remove(au);
                _iBookStoreIdentityDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAjax(int id)
        {
            try
            {
                //Author author = new Author { ID = id };
                //db.Entry(author).State = EntityState.Deleted;
                var au = _iBookStoreIdentityDbContext.Authors.Find(id);
                if (au != null)
                {
                    au.IsDeleted = true;
                    _iBookStoreIdentityDbContext.SaveChanges();
                }
                //db.Authors.Remove(au);
                //db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
