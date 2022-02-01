using EfeOtomasyonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfeOtomasyonBLL.Repositories
{
    public class CategoryRepository
    {
        EfeDBEntities db = DbTool.GetInstance();

        public bool Delete(int id)
        {
            if (id >= 1)
            {
                db.Categories.Remove(db.Categories.Find(id));
                bool sonuc = db.SaveChanges() > 0;
                return sonuc;
            }
            else
            {
                return false;
            }

        }

        public List<Category> GetData()
        {
            return db.Categories.ToList();
        }

        public bool Insert(Category item)
        {
            bool sonuc = false;
            try
            {
                if (item != null)
                {
                    db.Categories.Add(item);
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


        public Category SelectByID(int? id)
        {
            return db.Categories.Find(id);
        }

    }
}