using EfeOtomasyonBLL.Repositories;
using EfeOtomasyonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfeOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        EfeDBEntities db = DbTool.GetInstance();
        EmployeeRepository er = new EmployeeRepository();

        public void Need()
        {
            ViewBag.Employee = new SelectList(db.Employees.ToList(), "EmployeeID", "FirstName");
        }
        
        public ActionResult Index()
        {

            return View(er.GetData());
        }


        public ActionResult Insert()
        {
            Need();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Employee item)
        {
            if (item == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                bool sonuc = er.Insert(item);
                if (sonuc)
                {
                    ViewBag.Message = "Başarıyla kayıt edildi.";
                }
                else
                {
                    ViewBag.Message = "Kayıt işlemi sırasında hata meydana geldi.";
                }
            }
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Update(int id)
        {
            Need();
            return View(er.SelectByID(id));
        }

        [HttpPost]
        public ActionResult Update(Employee item)
        {
            Need();
            if (item == null)
                return HttpNotFound();

            bool sonuc = er.Update(item);
            if (sonuc)
            {
                ViewBag.Message = "Başarıyla güncellendi.";
            }
            else
            {
                ViewBag.Message = "Güncelleme işlemi sırasında bir hata oluştu.";
            }

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            bool sonuc = er.Delete(id);
            if (sonuc)
            {
                TempData["Message"] = "Silme işlemi başarıyla gerçekleşmiştir.";
            }
            else
            {
                TempData["Message"] = "Silme işlemi sırasında bir hata oluştu.";
            }
            return RedirectToAction("Index", "Employee");
        }
    }
}