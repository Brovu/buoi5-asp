using DataBase_Nhom2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBase_Nhom2.Controllers
{
    public class LevelController : Controller
    {
        // GET: Level
        public ActionResult Level()
        {
            return View(new CompanyEntities1().ChucVus.ToList());
        }

        public ActionResult AddLevel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLevel(ChucVu model)
        {
            CompanyEntities1 comp = new CompanyEntities1();

            if(comp.ChucVus.Any(x => x.maChucVu == model.maChucVu))
            {
                ModelState.AddModelError("maChucVu", "Mã chức vụ này đã tồn tại");
                return View(model);
            }
            comp.ChucVus.Add(model);
            comp.SaveChanges();
            return RedirectToAction("Level");
        }

        public ActionResult EditLevel(string id)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            var pb = comp.ChucVus.Find(id);
            return View(pb);
        }

        [HttpPost]
        public ActionResult EditLevel(ChucVu model)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            var newPb = comp.ChucVus.FirstOrDefault(x => x.maChucVu == model.maChucVu);

            if (newPb != null)
            {
                newPb.tenChucVu = model.tenChucVu;
                comp.SaveChanges();
                return RedirectToAction("Level");
            }
            else
            {

                return Content("Lỗi!");
            }
        }

        public ActionResult DeleteLevel(string id)
        {
            CompanyEntities1 comp = new CompanyEntities1();
            var model = comp.ChucVus.Find(id);
            comp.ChucVus.Remove(model);
            comp.SaveChanges();
            return RedirectToAction("Level");
        }
    }
}