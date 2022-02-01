using EfeOtomasyonBLL.Repositories;
using EfeOtomasyonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfeOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        EfeDBEntities db = DbTool.GetInstance();
        CategoryRepository cr = new CategoryRepository();

        public void Need()
        {
            ViewBag.Category = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName");
        }

        public ActionResult Index()
        {
            return View(cr.GetData());
        }

        public ActionResult Insert()
        {
            Need();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Category item)
        {
            if (item == null)
                return HttpNotFound();

            bool sonuc = cr.Insert(item);
            if (sonuc)
            {
                ViewBag.Message = "Başarıyla kayıt edildi.";
            }
            else
            {
                ViewBag.Message = "Kayıt işlemi sırasında hata meydana geldi.";
            }

            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete(int id)
        {
            bool sonuc = cr.Delete(id);
            if (sonuc)
            {
                TempData["Message"] = "Silme işlemi başarıyla gerçekleşmiştir.";
            }
            else
            {
                TempData["Message"] = "Silme işlemi sırasında bir hata oluştu.";
            }
            return RedirectToAction("Index", "Category");
        }
    }
}