using EfeOtomasyonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfeOtomasyonBLL.Repositories
{
    public class WorkOrderRepository
    {
        EfeDBEntities db = DbTool.GetInstance();

        public bool Delete(int id)
        {
            if (id >= 1)
            {
                db.WorkOrders.Remove(db.WorkOrders.Find(id));
                bool sonuc = db.SaveChanges() > 0;
                return sonuc;
            }
            else
            {
                return false;
            }

        }

        public List<WorkOrder> GetData()
        {
            return db.WorkOrders.ToList();
        }

        public bool UserChangePass(Employee item)
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

        public bool Insert(WorkOrder item)
        {
            bool sonuc = false;
            try
            {
                if (item != null)
                {
                    db.WorkOrders.Add(item);
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

        public bool Done(WorkDone item)
        {
            bool sonuc = false;
            try
            {
                if (item != null)
                {
                    db.WorkDones.Add(item);
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

        public bool Update(WorkOrder item)
        {
            bool sonuc = false;
            try
            {
                if (item != null)
                {
                    db.Entry(db.WorkOrders.Find(item.WorkID)).CurrentValues.SetValues(item);
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
        public WorkOrder SelectByID(int id)
        {
            return db.WorkOrders.Find(id);
        }

    }
}
