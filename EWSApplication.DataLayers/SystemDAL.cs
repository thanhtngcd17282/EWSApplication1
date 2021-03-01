using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWSApplication.Entities;
using EWSApplication.Entities.DBContext;

namespace EWSApplication.DataLayers
{
    public class SystemDAL
    {
        EWSDbContext db = new EWSDbContext();
        public User Login(string userName, string password)
        {
            User data = null;
            data = db.Users.Where(x => (x.username == userName && x.password == password) ).FirstOrDefault<User>();
            return data;
        }
    }
}
