using Model.Class;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class LoginDAO : ILoginDAO
    {
        private readonly IBookStoreIdentityDbContext _iBookStoreIdentityDbContext;

        public LoginDAO(IBookStoreIdentityDbContext iBookStoreIdentityDbContext)
        {
            _iBookStoreIdentityDbContext = iBookStoreIdentityDbContext;
        }

        public List<Login> TryLogin(string UserName, string Password)
        {
            var result = _iBookStoreIdentityDbContext.Logins.Where(x => x.username == UserName && x.password == Password).ToList();
            return result;
            //if (result > 0 )
            //    return true;
            //else
            //    return false;
        }
    }
}
