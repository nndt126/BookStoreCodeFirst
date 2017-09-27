using Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class UserDAO
    {
        BookStoreIdentityDbContext db = null;
        public UserDAO()
        {
            db = new BookStoreIdentityDbContext();
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Login(string UserName, string Password)
        {
            var result = db.Users.Count(x => x.UserName == UserName && x.Password == Password);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
