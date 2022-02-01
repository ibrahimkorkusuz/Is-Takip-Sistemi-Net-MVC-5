using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfeOtomasyonBLL
{
    public interface ICrud<T>
    {
        List<T> GetData();
        bool Insert(T item);
        bool Update(T item);
        bool Delete(int id);

        T SelectByID(int id);
    }
}
