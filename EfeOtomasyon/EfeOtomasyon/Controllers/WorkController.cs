using EfeOtomasyon.Models;
using EfeOtomasyonBLL.Repositories;
using EfeOtomasyonDAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfeOtomasyon.Controllers
{
    public class WorkController : Controller
    {
        EfeDBEntities db = DbTool.GetInstance();
        WorkOrderRepository wr = new WorkOrderRepository();

        public void Need()
        {
            ViewBag.Category = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName");
            ViewBag.Employee = new SelectList(db.Employees.ToList(), "EmployeeID", "FirstName");
            ViewBag.WorkOrder = new SelectList(db.WorkOrders.ToList(), "WorkID", "WorkName");
        }

        public ActionResult Index()
        {

            return View(wr.GetData());
        }


        public ActionResult Insert()
        {
            Need();
            return View();
        }

        [HttpPost]
        public ActionResult Insert(WorkOrder item, HttpPostedFileBase fluResim)
        {
            if (item == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                bool islemSonucu;
                FxFunction fx = new FxFunction();
                string donenDeger = fx.ImageUpload(fluResim, out islemSonucu);
                if (islemSonucu)
                {
                    item.ImagePath = donenDeger;
                }
                else
                {
                    ViewBag.Message = donenDeger;
                    return View();
                }

                bool sonuc = wr.Insert(item);
                if (sonuc)
                {
                    ViewBag.Message = "Başarıyla kayıt edildi.";
                }
                else
                {
                    ViewBag.Message = "Kayıt işlemi sırasında hata meydana geldi.";
                }
            }
            return RedirectToAction("Index", "Work");
        }

        public ActionResult Update(int id)
        {
            Need();
            return View(wr.SelectByID(id));
        }

        [HttpPost]
        public ActionResult Update(WorkOrder item)
        {
            Need();
            if (item == null)
                return HttpNotFound();

            bool sonuc = wr.Update(item);
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
            bool sonuc = wr.Delete(id);
            if (sonuc)
            {
                TempData["Message"] = "Silme işlemi başarıyla gerçekleşmiştir.";
            }
            else
            {
                TempData["Message"] = "Silme işlemi sırasında bir hata oluştu.";
            }
            return RedirectToAction("Index", "Work");
        }

        public ActionResult Done(int id)
        {
            Need();
            WorkOrder workOrder = db.WorkOrders.FirstOrDefault(WorkOrder => WorkOrder.WorkID == id);
            return View(workOrder);
        }

        [HttpPost]
        public ActionResult Done(WorkDone item)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = wr.Done(item);
                if (sonuc)
                {
                    ViewBag.Message = "Başarıyla kayıt edildi.";
                }
                else
                {
                    ViewBag.Message = "Kayıt işlemi sırasında hata meydana geldi.";
                }
            }
            return RedirectToAction("Done", "Work");
        }

        public ActionResult Detail(int id)
        {
            Need();
            return View(wr.SelectByID(id));
        }

        public ActionResult Test(int id)
        {
            Need();
            return View(wr.SelectByID(id));
        }

        [HttpPost]
        public ActionResult Test(WorkOrder item)
        {
            Need();
            if (item == null)
                return HttpNotFound();

            bool sonuc = wr.Update(item);
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
    }
}