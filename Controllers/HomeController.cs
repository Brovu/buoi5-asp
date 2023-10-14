using DataBase_Nhom2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBase_Nhom2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new CompanyEntities1().PhongBans.ToList());
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(PhongBan model)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            comp.PhongBans.Add(model);
            comp.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditRole(int id)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            PhongBan pb = comp.PhongBans.Find(id);
            return View(pb);
        }

        [HttpPost]
        public ActionResult EditRole(PhongBan model)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            var newPb = comp.PhongBans.Find(model.maPhong);

            newPb.maPhong = model.maPhong;
            newPb.tenPhong = model.tenPhong;
            comp.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRole(int id)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            var model = comp.PhongBans.Find(id);
            comp.PhongBans.Remove(model);
            comp.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}