using Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class PhanQuyenDAO
    {
        BookStoreIdentityDbContext db = null;
        public PhanQuyenDAO()
        {
            db = new BookStoreIdentityDbContext();
        }

        public string CheckRoles(int id)
        {
            var result = db.PhanQuyens.Where(x => x.ID == id).Select(t=> t.RoleName).ToString();
            return result;
        }
    }
}
