using Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IAuthorDAO
    {
        IEnumerable<Author> GetAllAuthors();
        List<Author> GetAuthors();

        List<Author> GetAllAuthorsAdmin();
        List<Author> GetAuthorPaging(string sortOrder, string searchString, int numberItem, int pageSize);
        int Insert(Author au);
        Author GetAuthorByID(int? id);
        bool Update(Author author);
        bool Delete(int id);
        bool DeleteAjax(int id);
    }
}
