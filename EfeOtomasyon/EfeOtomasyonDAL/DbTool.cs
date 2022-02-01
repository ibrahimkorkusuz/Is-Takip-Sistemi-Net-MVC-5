using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfeOtomasyonDAL
{
    public class DbTool
    {
        private static EfeDBEntities _instance;
        private DbTool() { }
        public static EfeDBEntities GetInstance()
        {
            if (_instance == null)
                _instance = new EfeDBEntities();

            return _instance;
        }
    }
}
