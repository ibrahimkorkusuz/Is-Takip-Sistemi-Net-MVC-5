using EfeOtomasyonBLL.Repositories;
using EfeOtomasyonDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfeOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        EfeDBEntities db = DbTool.GetInstance();
        EmployeeRepository er = new EmployeeRepository();

        public void Need()
        {
            ViewBag.Employee = new SelectList(db.Employees.ToList(), "EmployeeID", "FirstName");
        }

        public ActionResult Index()
        {
            Need();
            return View();
        }


        public ActionResult Login()
        {
            Need();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee item)
        {
            if (er.Any(item.Email, item.Password))
            {
                Employee loginEmp = er.GetEmployee(item.Email, item.Password);
                Session["employee"] = loginEmp;
                return RedirectToAction("Index", "Work");
            }
            else
            {
                ViewBag.Message = "Bu kullanıcı sistemde kayıtlı değildir.";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}