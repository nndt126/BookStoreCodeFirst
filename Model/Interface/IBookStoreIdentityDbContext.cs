using Model.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IBookStoreIdentityDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Login> Logins { get; set; }
        DbSet<PhanQuyen> PhanQuyens { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
        void SetModified(object entity);
    }
}
