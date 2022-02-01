using EfeOtomasyonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfeOtomasyonBLL.Repositories
{
    public class EmployeeRepository
    {
        EfeDBEntities db = DbTool.GetInstance();

        public bool Delete(int id)
        {
            if (id >= 1)
            {
                db.Employees.Remove(db.Employees.Find(id));
                bool sonuc = db.SaveChanges() > 0;
                return sonuc;
            }
            else
            {
                return false;
            }

        }

        public List<Employee> GetData()
        {
            return db.Employees.ToList();
        }

        public bool Insert(Employee item)
        {
            bool sonuc = false;
            try
            {
                if (item != null)
                {
                    db.Employees.Add(item);
                    sonuc = db.SaveChanges() > 0;
                    return sonuc;
                }
                else
                    return sonuc;
            }
            catch (Exception)
            {

                return sonuc;
            }
        }

        public bool Update(Employee item)
        {
            bool sonuc = false;
            try
            {
                db.Entry(db.Employees.Find(item.EmployeeID)).CurrentValues.SetValues(item);
                sonuc = db.SaveChanges() > 0;
                return sonuc;
            }
            catch (Exception)
            {
                return sonuc;
            }
        }
        public Employee SelectByID(int? id)
        {
            return db.Employees.Find(id);
        }

        public bool Any(string email, string pass)
        {
            return db.Employees.Any(e => e.Email == email && e.Password == pass);
        }

        public Employee GetEmployee(string email, string pass)
        {
            return db.Employees.FirstOrDefault(e => e.Email == email && e.Password == pass);
        }

    }
}
