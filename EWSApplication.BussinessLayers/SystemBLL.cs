using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWSApplication.DataLayers;
using EWSApplication.Entities.DBContext;
namespace EWSApplication.BussinessLayers
{
    public class SystemBLL
    {
        private static SystemDAL SysDal = new SystemDAL();
        public static User System_Login(string userName, string password)
        {
            return SysDal.Login(userName, password);
        }
    }
}
